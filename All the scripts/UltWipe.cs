using UnityEngine;

public class ScreenWipe : MonoBehaviour
{
    public float moveSpeed = 10f; // laju gerak si grafik ulti

    void Update()
    {
        // Jalanin grafik ulti kiri ke kanan (kucingnya nanti jalan searah itu)
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // Hilangkan objek kalau udah keluar screen
        if (transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + 1)
        {
            Destroy(gameObject);
        }
    }
}
