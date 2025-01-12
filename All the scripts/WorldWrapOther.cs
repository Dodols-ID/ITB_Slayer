using UnityEngine;

// teleport objek selain player pas di teleport
public class EnemyWorldWrap : MonoBehaviour
{
    void OnEnable()
    {
        // semua objek di teleport ke sisi ujung
        PlayerWorldWrap.PlayerWrapped += OnPlayerWrapped;
    }

    void OnDisable()
    {
        // Unsubscribe biar nggak memory leak
        PlayerWorldWrap.PlayerWrapped -= OnPlayerWrapped;
    }

    private void OnPlayerWrapped(Vector3 offset)
    {
        // ambil posisi player sebegai referensi teleport
        transform.position += offset;
    }
}
