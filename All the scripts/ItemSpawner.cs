using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // Reference to the item prefab
    public float spawnChance = 0.1f; // The chance for the item to spawn (0 to 1)
    public float spawnInterval = 5f; // Time interval between each spawn check

    void Start()
    {
        // Start the spawn checking loop
        InvokeRepeating("TrySpawnItem", 0f, spawnInterval);
    }

    void TrySpawnItem()
    {
        // Generate a random number between 0 and 1
        float chance = Random.value;

        // If the chance is less than the spawnChance, spawn the item
        if (chance < spawnChance)
        {
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        // Get random screen coordinates within the camera's view
        Vector2 spawnPosition = new Vector2(
            Random.Range(-Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * Camera.main.aspect),
            Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize)
        );

        // Instantiate the item at the random position
        Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
    }
}
