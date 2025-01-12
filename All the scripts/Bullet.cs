using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 25f; // Damage bullet biasa (placeholder)
    public float lifespan = 5f; // Waktu sebelum bullet menghilang (bullet nggak akan floting selamanya)

    private void Start()
    {
        // Setelah waktu 'lifespan' habis, bullet dihilangkan
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collider triggered with: " + other.gameObject.name);
        // Cek ketika bullet kena musuh
        if (other.CompareTag("Enemy"))
        {
            // Kurangin HP musuh
            Debug.Log("Bullet hit.");
            EnemyDeath enemy = other.GetComponent<EnemyDeath>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Damage applied.");
            }

            // Hilangkan objek bullet setelah kena musuh
            Debug.Log("Bullet destroy: " + gameObject.name);
            Destroy(gameObject);
        }
    }
}
