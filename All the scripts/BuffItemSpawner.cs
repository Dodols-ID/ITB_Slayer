using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab; 
    public float spawnChance = 0.1f; // Kemungkinan si itemnya ngespawn (placeholder)
    public float spawnInterval = 5f; // Seberapa cepet sebelum itemnya dicek bisa ngespawn lagi atau nggak berdasar spawn chance

    void Start()
    {
        // Mulai pengecekan kalau itemnya collide sama player, ato diambil sama playernya
        InvokeRepeating("TrySpawnItem", 0f, spawnInterval);
    }

    void TrySpawnItem()
    {
        // Bikin angka diantara 0 sampai 1
        float chance = Random.value;

        // kalau angka chance lebih kecil dari spawnchance, item di spawn
        if (chance < spawnChance)
        {
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        // Ambil lokasi ato koordinat random
        Vector2 spawnPosition = new Vector2(
            Random.Range(-Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * Camera.main.aspect),
            Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize)
        );

        // Taroh prefab dari item yang pake skrip ini ke lokasi random itu
        Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
    }
}
