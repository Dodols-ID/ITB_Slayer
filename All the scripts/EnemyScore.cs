using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Attributes")]
    public string enemyType;
    public int scoreValue = 20;    
    public int health = 100;       
    public float speed = 2f;       

    private void OnDestroy()
    {
        // Logic buat skor
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(scoreValue);
        }
        Debug.Log($"{enemyType} Enemy killed. Score: {scoreValue}");
    }
}
