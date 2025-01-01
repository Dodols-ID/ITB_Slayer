using UnityEngine;

public class PickupLogic : MonoBehaviour
{
    public int ultIncrement = 1; // Amount to increment ultCount

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ultimate item picked up!");

            // Increment the ultimate count
            PlayerShoot playerShoot = other.GetComponent<PlayerShoot>();
            if (playerShoot != null)
            {
                playerShoot.ultCount += ultIncrement;
                Debug.Log($"Ultimate Count: {playerShoot.ultCount}");
            }

            // Destroy the item after pickup
            Destroy(gameObject);
        }
    }
}
