using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
public void GameOver()
{
    ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
    if (scoreManager != null)
    {
        scoreManager.ResetScore(); // Reset score
    }

    // Additional game-over logic
}

}
