using UnityEngine;
using TMPro;

// UI skor di play screen
public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    void Start()
    {
        UpdateScoreUI();
    }
    // kalau ada aktivitas yang nambahin skor, skor ditambah
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }
    // di game over, skor di reset
    public void ResetScore()
    {
        score = 0; // Reset the score
        UpdateScoreUI(); // Update the UI
    }
    // skor yang dimunculkan di UI play screen
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = " " + score;
        }
    }
}
