using UnityEngine;

// konsepnya si duniany infinite, padahal cuman area yang kalau player udah sampai ujung, di teleport to the opposite side

public class PlayerWorldWrap : MonoBehaviour
{
    public float boundaryX = 10f;
    public float boundaryY = 10f;

    public delegate void OnPlayerWrap(Vector3 offset);
    public static event OnPlayerWrap PlayerWrapped; // Event yang jadi cue teleport item di skrip worldwrapother
    void Update()
    {
        Vector3 newPosition = transform.position;
        Vector3 offset = Vector3.zero;

        // posisi teleport arah horizontal
        if (transform.position.x > boundaryX)
        {
            offset.x = -2 * boundaryX;
            newPosition.x = -boundaryX;
        }
        else if (transform.position.x < -boundaryX)
        {
            offset.x = 2 * boundaryX;
            newPosition.x = boundaryX;
        }

        // posisi teleport arah vertikal
        if (transform.position.y > boundaryY)
        {
            offset.y = -2 * boundaryY;
            newPosition.y = -boundaryY;
        }
        else if (transform.position.y < -boundaryY)
        {
            offset.y = 2 * boundaryY;
            newPosition.y = boundaryY;
        }

        if (offset != Vector3.zero)
        {
            // dari value arah yang diperoleh, player di teleport
            transform.position = newPosition;

            // invoke event biar objek lain teleport juga
            PlayerWrapped?.Invoke(offset);
        }
    }
}
