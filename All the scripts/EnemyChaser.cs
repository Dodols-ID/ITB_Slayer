using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    public Transform player; 
    public float speed = 2f; // Seberapa cepet musuh bergerak

    void Start()
    {
        // Cari objek yang punya tag "Player", basically playernya (cuman satu)
        player = GameObject.FindWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("Player object not found in scene. Player tag object might be missing");
        }
    }
    void Update()
    {
        if (player != null)
        {
            // Kalkulasi jarak dari objek musuh ini ke player
            Vector3 direction = (player.position - transform.position).normalized;

            // Ubah arah musuh untuk "ngarah", "ngehadep" ke player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // Musuh maju ke arah pemain
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
