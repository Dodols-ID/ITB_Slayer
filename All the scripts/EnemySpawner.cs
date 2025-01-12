using UnityEngine;

// Dipasang di objek yang bakal jadi 'spawner', atau kalau nanti nggak sempet jadi spawn point
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f; // Rate musuh di spawn (placeholder)
    public float spawnRadius = 5f; // Jarak musuh di spawn dari spawner

    // Saat scene mulai, musuh mulai di spawn
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }
    // Logic spawningnya
    void SpawnEnemy()
    {
        Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
