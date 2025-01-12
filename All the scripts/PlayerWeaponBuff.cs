using UnityEngine;
using System.Collections;
public class PlayerWeapon : MonoBehaviour
{
    public Weapon currentWeapon;    
    public Weapon basicWeapon;
    public Weapon heavyWeapon;

    private float originalDamage;
    private float originalFireRate;

    private void Start()
    {
        if (currentWeapon != null)
        {
            // stat awal senjata diambil
            originalDamage = currentWeapon.damage;
            originalFireRate = currentWeapon.fireRate;
        }
    }

    // Pas buff diambil
    public void ApplyBuff(float damageMultiplier, float fireRateMultiplier, float duration)
    {
        if (currentWeapon != null)
        {
            // masukin stat weapon setelah buff
            currentWeapon.damage *= damageMultiplier;
            currentWeapon.fireRate *= fireRateMultiplier;

            Debug.Log($"Buff. New Damage: {currentWeapon.damage}, New Fire Rate: {currentWeapon.fireRate}");

            // coroutine buat durasi buff
            StartCoroutine(RemoveBuffAfterDuration(duration));
        }
    }

    private IEnumerator RemoveBuffAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);

        if (currentWeapon != null)
        {
            // Stat awal weapon balik setelah durasi habis
            currentWeapon.damage = originalDamage;
            currentWeapon.fireRate = originalFireRate;

            Debug.Log($"Buff expired. Reverted Damage: {currentWeapon.damage}, Reverted Fire Rate: {currentWeapon.fireRate}");
        }
    }
}
