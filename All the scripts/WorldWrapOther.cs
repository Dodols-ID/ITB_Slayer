using UnityEngine;

public class EnemyWorldWrap : MonoBehaviour
{
    void OnEnable()
    {
        // Subscribe to the player's wrapping event
        PlayerWorldWrap.PlayerWrapped += OnPlayerWrapped;
    }

    void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        PlayerWorldWrap.PlayerWrapped -= OnPlayerWrapped;
    }

    private void OnPlayerWrapped(Vector3 offset)
    {
        // Adjust enemy position based on the player's wrapping offset
        transform.position += offset;
    }
}
