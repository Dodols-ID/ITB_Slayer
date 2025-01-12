using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        if (player != null)
        {
            // Kamera bergerak terus mengacu ke posisi player
            transform.position = new Vector3(player.position.x, player.position.y, -10f);
        }
    }
}
