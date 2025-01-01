using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Attributes")]
    public string enemyType;       // Name or type of the enemy (optional, for identification)
    public int scoreValue = 20;    // Score value for defeating this enemy
    public int health = 100;       // Health for the enemy
    public float speed = 2f;       // Speed of the enemy

    private void OnDestroy()
    {
        // Handle scoring when the enemy is destroyed
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(scoreValue);
        }

        // You could add additional behavior for different types of enemies
        Debug.Log($"{enemyType} destroyed! Score: {scoreValue}");
    }
}
