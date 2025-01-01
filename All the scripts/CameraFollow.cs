using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform

    void LateUpdate()
    {
        if (player != null)
        {
            // Follow the player's position
            transform.position = new Vector3(player.position.x, player.position.y, -10f);
        }
    }
}
