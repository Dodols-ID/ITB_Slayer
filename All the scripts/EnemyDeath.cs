using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float health = 50f; // The enemy's health

    // Method to apply damage
    public void TakeDamage(float damage)
    {
        health -= damage;  // Reduce health by the damage amount
        Debug.Log("Enemy hit! Remaining health: " + health);

        if (health <= 0)
        {
            Die();  // Call Die() when health reaches 0
        }
    }

    // Method to handle enemy death
    void Die()
    {
        Debug.Log("Enemy died!");
        // Add your death logic here (e.g., destroy the enemy object)
        Destroy(gameObject);
    }
}
