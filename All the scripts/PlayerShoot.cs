using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Weapon currentWeapon; // Weapon aktif
    public Weapon basicWeapon;    // Refer ke Basic Weapon
    public Weapon heavyWeapon;    // Refer ke Heavy weapon
    public Transform shootPoint;    // TItik bullet di spawn

    private float nextFireTime = 0f; // Timer buat delay nembak pas switiching senjata
    private float overheatThreshold = 0f; // Value overheat Heavy Weapon
    private float overheatCooldownTime = 0f; // Waktu overheat selesai (kalau overheat)
    public float overheatRate = 1f; // Rate overheat heavy weapon
    public float maxOverheat = 100f; // Threshold weapon sebelum overheat
    public float cooldownRate = 5f; // Kalau nggak overheat dan sejata nggak ditembak, seberapa cepet meter overheatnya turun
    public float overheatCooldownDuration = 2f; // Kalau overheat, seberapa lama senjata disabled
    public int ultCount;
    public GameObject screenWipeEffect; // referense efek screen wipe ulti
    void Start()
    {
    // Senjata pas game dibuat basic weapon
        currentWeapon = basicWeapon;
    }

void Update()
{
    // Debug senjata + variabel overheat
    Debug.Log($"Current Weapon: {currentWeapon?.weaponName} Overheat: {overheatThreshold}");

    // Heavy weapon switch (press z)
    if (Input.GetKey(KeyCode.Z))
    {
        currentWeapon = heavyWeapon;
    }
    else if (!Input.GetKey(KeyCode.Z))
    {
        currentWeapon = basicWeapon;
    }

    // Kalau overheat, heavy weapon nggak bisa dipakai, tapi basic weapon tetep bisa jalan
    if (overheatCooldownTime > 0f)
    {
        overheatCooldownTime -= Time.deltaTime; // Mengurangi lama heavy weapon nggak bisa dipakai saat overheat
        Debug.Log($"Weapon is in cooldown: {overheatCooldownTime}s left");

        if (overheatCooldownTime <= 0f)
        {
            overheatThreshold = 0;
        }

        // Cek kalau currentweapon heavy (kalau z masih dipencet), dan lanngsung ganti ke basic lagi (karena ada delay, nggak akan rusak lagi kayak sebelumnya)
        if (currentWeapon.weaponName == "Heavy")
        {
            currentWeapon = basicWeapon;
            return;
        }
    }

    // Cek currentweapon Heavy dan tombol z dipencet dan dalam overheat cooldown atau nggak
    if (currentWeapon != null && currentWeapon.weaponName == "Heavy" && Input.GetKey(KeyCode.Z) && overheatThreshold < maxOverheat)
    {
        Debug.Log("Z pressed, initiating Heavy Weapon");
        // Tembak ke musuh terdekat
        if (Time.time >= nextFireTime)
        {
            ShootAtNearestEnemy();
        }

        // overheat threshhold ditambah seiring heavy weapon ditembakin
        overheatThreshold += overheatRate * Time.deltaTime;

        // kalau overheat, heavy weapon disabled
        if (overheatThreshold >= maxOverheat)
        {
            overheatThreshold = maxOverheat; // Ensure it doesn’t go above max
            overheatCooldownTime = overheatCooldownDuration; // Start the cooldown period
            Debug.Log("Heavy overheat");
        }
    }
    // Kalau heavy weapon nggak dipake, tembak pakai Basic Weapon
    else if (currentWeapon != null && currentWeapon.weaponName == "Basic")
    {
        // Penembakan otomatis (nggak pakai tombol)
        if (Time.time >= nextFireTime)
        {
            ShootAtNearestEnemy();
        }
         if (overheatThreshold > 0f)
        {
            overheatThreshold -= cooldownRate * Time.deltaTime;
        }
    }
    // Kalau sempet pickup ulti dan x ditekan
    if (Input.GetKeyDown(KeyCode.X) && ultCount > 0)
    {
        ActivateScreenWipe();
    }
}


void ActivateScreenWipe()
{
    Debug.Log("Ultimate activated!");
    
    // Spawn grafik ultinya (kucing di bis itu)
    if (screenWipeEffect != null)
    {
        Vector3 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 10));
        GameObject effect = Instantiate(screenWipeEffect, startPosition, Quaternion.identity);

    }

    // Hilangkan semua enemy on screen
    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

    foreach (GameObject enemy in enemies)
    {
        Destroy(enemy);
    }

    // Set jumlah ulti jadi 0
    ultCount = 0;

    Debug.Log($"Cato used");
}

// Track musuh dan tembak
void ShootAtNearestEnemy()
{

    // Cari objek dengan tag "Enemy" (jan lupa buat yang enemy barunya)
    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

    // Kalau nggak ada yang kedeteksi, nggak ada bullet yang ditembak
    if (enemies.Length == 0)
        return;

    // Cari musuh terdekat
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

        // Kalau ada musuh, tembak sesuai arah musuh
        if (nearestEnemy != null)
        {
            Vector3 direction = nearestEnemy.transform.position - shootPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            shootPoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            
            if (currentWeapon.bulletPrefab != null)
            {
                GameObject bullet = Instantiate(currentWeapon.bulletPrefab, shootPoint.position, shootPoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.AddForce(direction.normalized * currentWeapon.shootForce, ForceMode2D.Impulse);
                }

                Debug.Log("Shooting this enemy: " + nearestEnemy.name);

                
                nextFireTime = Time.time + currentWeapon.fireRate;
            }
            else
            {
                // just in case pas nambah weapon baru ada bug, mungkin si prefab musuhnya kelupaaan (tapi jangan sampe lupa juga ya)
                Debug.LogWarning("No bulletPrefab assigned to weapon: " + currentWeapon.weaponName);
            }
        }
    }
    // Weapon switchin
    public void ChangeWeapon(Weapon newWeapon)
    {
        if (newWeapon == null)
        {
            // kalau nanti si indeks senjatanya kosong
            Debug.LogWarning("Attempted to switch to a null weapon!");
            return;
        }

        // ganti nama currentweapon yang udah di switch
        currentWeapon = newWeapon;

        // Delay setiap bullet yang ditembak senjata di reset jadi bisa langsung tembak
        nextFireTime = Time.time;
    }
}
