using UnityEngine;

public class PickupLogic : MonoBehaviour
{
    public int ultIncrement = 1; // Jumlah ulti yang ditambah kalau item ulti dipickup

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek collider player dan item ulti
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ult item picked up");

            // Tambah jumlah ulti player (yang memungkikan ulti unutk di cast)
            PlayerShoot playerShoot = other.GetComponent<PlayerShoot>();
            if (playerShoot != null)
            {
                playerShoot.ultCount += ultIncrement;
                Debug.Log($"Ult count {playerShoot.ultCount}");
            }

            // Hilangkan objek setelah pickup
            Destroy(gameObject);
        }
    }
}
