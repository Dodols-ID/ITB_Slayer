using UnityEngine;

public class BuffPickup : MonoBehaviour
{
    public float damageMultiplier = 3f;  // Buff multiplier for damage
    public float fireRateMultiplier = 3f; // Buff multiplier for fire rate
    public float duration = 5f;  // Duration of the buff in seconds

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply the buff to the player's weapon
            PlayerWeapon playerWeapon = other.GetComponent<PlayerWeapon>();
            if (playerWeapon != null)
            {
                playerWeapon.ApplyBuff(damageMultiplier, fireRateMultiplier, duration);
            }

            // Destroy the buff pickup object after it is collected
            Destroy(gameObject);
        }
    }
}
