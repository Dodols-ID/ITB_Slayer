using UnityEngine;

public class PlayerWorldWrap : MonoBehaviour
{
    public float boundaryX = 10f;
    public float boundaryY = 10f;

    public delegate void OnPlayerWrap(Vector3 offset);
    public static event OnPlayerWrap PlayerWrapped; // Event to notify enemies

    void Update()
    {
        Vector3 newPosition = transform.position;
        Vector3 offset = Vector3.zero;

        // Wrap horizontally
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

        // Wrap vertically
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
            // Apply the teleport
            transform.position = newPosition;

            // Notify enemies about the wrapping
            PlayerWrapped?.Invoke(offset);
        }
    }
}
