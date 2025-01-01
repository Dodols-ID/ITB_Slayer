using UnityEngine;
using System.Collections;
public class PlayerWeapon : MonoBehaviour
{
    public Weapon currentWeapon;    // The active weapon (Basic or Heavy)
    public Weapon basicWeapon;      // Reference to the Basic weapon
    public Weapon heavyWeapon;      // Reference to the Heavy weapon

    private float originalDamage;
    private float originalFireRate;

    private void Start()
    {
        if (currentWeapon != null)
        {
            // Store original stats for the current weapon
            originalDamage = currentWeapon.damage;
            originalFireRate = currentWeapon.fireRate;
        }
    }

    // This method will be called by the buff pickup
    public void ApplyBuff(float damageMultiplier, float fireRateMultiplier, float duration)
    {
        if (currentWeapon != null)
        {
            // Apply the buff to the current weapon's stats
            currentWeapon.damage *= damageMultiplier;
            currentWeapon.fireRate *= fireRateMultiplier;

            Debug.Log($"Buff applied! New Damage: {currentWeapon.damage}, New Fire Rate: {currentWeapon.fireRate}");

            // Start a coroutine to remove the buff after the specified duration
            StartCoroutine(RemoveBuffAfterDuration(duration));
        }
    }

    private IEnumerator RemoveBuffAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);

        if (currentWeapon != null)
        {
            // Revert to the original weapon stats
            currentWeapon.damage = originalDamage;
            currentWeapon.fireRate = originalFireRate;

            Debug.Log($"Buff expired. Reverted Damage: {currentWeapon.damage}, Reverted Fire Rate: {currentWeapon.fireRate}");
        }
    }
}
