using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 25f; // Amount of damage the bullet does
    public float lifespan = 5f; // Time in seconds before the bullet gets destroyed

    private void Start()
    {
        // Destroy the bullet after 'lifespan' seconds
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collider triggered with: " + other.gameObject.name);
        // Check if the bullet hit an enemy
        if (other.CompareTag("Enemy"))
        {
            // Apply damage to the enemy (we'll implement this in the enemy script)
            Debug.Log("Bullet hit an enemy!");
            EnemyDeath enemy = other.GetComponent<EnemyDeath>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Damage applied to enemy");
            }

            // Destroy the bullet (for now, let's just destroy it)
            Debug.Log("Destroying bullet: " + gameObject.name);
            Destroy(gameObject);
        }
    }
}
