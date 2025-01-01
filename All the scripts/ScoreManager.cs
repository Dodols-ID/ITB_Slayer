using UnityEngine;
using TMPro; // Include the TMP namespace

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // The player's score
    public TMP_Text scoreText; // Reference to the TMP_Text component

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount; // Increase the score
        UpdateScoreUI(); // Update the UI
    }

    public void ResetScore()
    {
        score = 0; // Reset the score
        UpdateScoreUI(); // Update the UI
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = " " + score; // Display the score
        }
    }
}
