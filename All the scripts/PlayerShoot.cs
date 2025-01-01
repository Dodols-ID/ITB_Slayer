using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Weapon currentWeapon; // The active weapon
    public Weapon basicWeapon;    // Reference to the Basic weapon
    public Weapon heavyWeapon;    // Reference to the Heavy weapon
    public Transform shootPoint;    // The position where bullets are spawned

    private float nextFireTime = 0f; // Timer to track when the player can shoot next
    private float overheatThreshold = 0f; // Track the overheat of the weapon
    private float overheatCooldownTime = 0f; // Time to wait before the weapon can be used again after overheating
    public float overheatRate = 1f; // How quickly the weapon overheats while firing
    public float maxOverheat = 100f; // The maximum threshold before overheating
    public float cooldownRate = 5f; // Rate at which overheat cools down when not firing
    public float overheatCooldownDuration = 2f; // How long to wait before the weapon can be used again after overheating
    public int ultCount;
    public GameObject screenWipeEffect; // Reference to the screen wipe sprite or effect
    void Start()
    {
    // Set the initial weapon to Basic (or whichever weapon you want to start with)
        currentWeapon = basicWeapon;
    }

void Update()
{
    // Debug: Print current weapon and overheat
    Debug.Log($"Current Weapon: {currentWeapon?.weaponName}, Overheat: {overheatThreshold}");

    // Only switch to the heavy weapon when Q is pressed
    if (Input.GetKey(KeyCode.Z))
    {
        currentWeapon = heavyWeapon;
    }
    else if (!Input.GetKey(KeyCode.Z))
    {
        currentWeapon = basicWeapon;
    }

    // If the weapon is in cooldown, prevent shooting only if it's the heavy weapon
    if (overheatCooldownTime > 0f)
    {
        overheatCooldownTime -= Time.deltaTime; // Decrease cooldown time
        Debug.Log($"Weapon is in cooldown: {overheatCooldownTime}s left");

        if (overheatCooldownTime <= 0f)
        {
            overheatThreshold = 0;
        }

        // If the current weapon is heavy, prevent shooting
        if (currentWeapon.weaponName == "Heavy")
        {
            currentWeapon = basicWeapon;
            return;
        }
    }

    // Check if the current weapon is the heavy weapon and if the Q key is being held
    if (currentWeapon != null && currentWeapon.weaponName == "Heavy" && Input.GetKey(KeyCode.Z) && overheatThreshold < maxOverheat)
    {
        Debug.Log("Q key is being pressed");
        // If the heavy weapon is being held, shoot at the nearest enemy
        if (Time.time >= nextFireTime)
        {
            ShootAtNearestEnemy();
        }

        // Increase the overheat threshold while firing
        overheatThreshold += overheatRate * Time.deltaTime;

        // If overheat threshold reaches maximum, prevent shooting
        if (overheatThreshold >= maxOverheat)
        {
            overheatThreshold = maxOverheat; // Ensure it doesn’t go above max
            overheatCooldownTime = overheatCooldownDuration; // Start the cooldown period
            Debug.Log("Weapon is overheated!");
        }
    }
    else if (currentWeapon != null && currentWeapon.weaponName == "Basic")
    {
        // Automatically shoot with the basic weapon (no need to hold Q)
        if (Time.time >= nextFireTime)
        {
            ShootAtNearestEnemy();
        }
         if (overheatThreshold > 0f)
        {
            overheatThreshold -= cooldownRate * Time.deltaTime;
        }
    }

    if (Input.GetKeyDown(KeyCode.X) && ultCount > 0)
    {
        ActivateScreenWipe();
    }
}


void ActivateScreenWipe()
{
    Debug.Log("Ultimate activated!");
    
    // Trigger screen wipe animation
    if (screenWipeEffect != null)
    {
        Vector3 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 10));
        GameObject effect = Instantiate(screenWipeEffect, startPosition, Quaternion.identity);

    }

    // Destroy all enemies
    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

    foreach (GameObject enemy in enemies)
    {
        Destroy(enemy);
    }

    // Decrease ultCount
    ultCount--;

    Debug.Log($"Ultimate used. Remaining ultCount: {ultCount}");
}


void ShootAtNearestEnemy()
{
    if (overheatThreshold >= maxOverheat) return; // Prevent shooting if overheated

    // Find all enemies in the scene with the "Enemy" tag
    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

    if (enemies.Length == 0)
        return;

    // Find the closest enemy
    GameObject nearestEnemy = null;
    float minDistance = Mathf.Infinity;

    foreach (GameObject enemy in enemies)
    {
        float distance = Vector2.Distance(transform.position, enemy.transform.position);
        if (distance < minDistance && distance <= currentWeapon.range)
        {
            nearestEnemy = enemy;
            minDistance = distance;
        }
    }

        // If there's a valid nearest enemy, aim and shoot at it
        if (nearestEnemy != null)
        {
            Vector3 direction = nearestEnemy.transform.position - shootPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            shootPoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Use the bulletPrefab from the currentWeapon (whether it's the basic or heavy weapon)
            if (currentWeapon.bulletPrefab != null)
            {
                GameObject bullet = Instantiate(currentWeapon.bulletPrefab, shootPoint.position, shootPoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.AddForce(direction.normalized * currentWeapon.shootForce, ForceMode2D.Impulse);
                }

                Debug.Log("Shooting at enemy: " + nearestEnemy.name);

                // Reset the fire timer
                nextFireTime = Time.time + currentWeapon.fireRate;
            }
            else
            {
                Debug.LogWarning("No bulletPrefab assigned to weapon: " + currentWeapon.weaponName);
            }
        }
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        if (newWeapon == null)
        {
            Debug.LogWarning("Attempted to switch to a null weapon!");
            return;
        }

        // Update the shooting parameters to match the new weapon
        currentWeapon = newWeapon;

        // Reset fire timer to allow immediate firing with the new weapon
        nextFireTime = Time.time;

        // Reset overheat threshold when switching weapon
        overheatThreshold = 0f;

        // Reset cooldown time when switching weapon
        overheatCooldownTime = 0f;

        Debug.Log($"Switched to weapon: {newWeapon.weaponName} with fire rate: {newWeapon.fireRate}");
    }
}
