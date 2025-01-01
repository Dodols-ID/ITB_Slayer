using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    public Transform player; // Reference to the player's Transform
    public float speed = 2f; // Movement speed of the enemy

    void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("Player object not found in the scene. Make sure the player has the 'Player' tag.");
        }
    }
    void Update()
    {
        if (player != null)
        {
            // Calculate direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Rotate enemy to face the player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // Move the enemy in the direction of the player
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
