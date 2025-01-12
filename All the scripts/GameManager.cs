using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
// Apa aja yang harus dilakuin pas game selesai
public void GameOver()
{
    ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
    if (scoreManager != null)
    {
        scoreManager.ResetScore(); // Reset score jadi 0 lagi. Btw, nanti kalau bisa ada logic buat ngambil data ini buat ditampilin di layar game over
    }

}

}
