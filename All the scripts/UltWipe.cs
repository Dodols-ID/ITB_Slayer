using UnityEngine;

public class ScreenWipe : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed of the ultimate effect

    void Update()
    {
        // Move the ultimate object from left to right
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // Destroy the object when it moves out of the screen
        if (transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + 1)
        {
            Destroy(gameObject);
        }
    }
}
