using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float health = 50f; // HP musuh (placeholder)

    
    public void TakeDamage(float damage)
    {
        health -= damage;  // kurangin HPnya kalau kena bullet
        Debug.Log("Enemy hit. Remaining health: " + health);

        if (health <= 0)
        {
            Die();  // Call Die() kalau HPnya dibawah 0
        }
    }

    
    void Die()
    {
        Debug.Log("Enemy killed!");
        // Hilangkan objek kalau 'mati'
        Destroy(gameObject);
    }
}
