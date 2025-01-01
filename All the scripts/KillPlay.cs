using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public static RestartManager Instance; // Singleton for global access

    [SerializeField] private GameObject restartScreen; // Assign the restart screen panel in the Inspector

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowRestartScreen()
    {
        if (restartScreen != null)
        {
            restartScreen.SetActive(true); // Show the restart screen
            Time.timeScale = 0f; // Pause the game
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }
}
