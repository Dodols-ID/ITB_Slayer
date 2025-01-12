using UnityEngine;

public class Bufflogic : MonoBehaviour
{
    public float damageMultiplier = 3f;  // Buff multiplier buat damage
    public float fireRateMultiplier = 3f; // Buff multiplier buat fire rate
    public float duration = 5f;  // Durasi buff dalam detik

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply buff untuk player sesuai buff yang diperoleh
            PlayerWeapon playerWeapon = other.GetComponent<PlayerWeapon>();
            if (playerWeapon != null)
            {
                playerWeapon.ApplyBuff(damageMultiplier, fireRateMultiplier, duration);
            }

            // Hilangkan objek setelah diambil
            Destroy(gameObject);
        }
    }
}
