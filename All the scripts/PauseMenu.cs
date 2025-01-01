using UnityEngine;
using UnityEngine.SceneManagement; // For loading scenes like the main menu
using UnityEngine.UI; // For Button functionality

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the Pause Menu UI
    public Button resumeButton; // Reference to the Resume Button
    public Button mainMenuButton; // Reference to the Main Menu Button
    public Button pauseButton; // Reference to the button that triggers the pause menu

    public bool isPaused = false; // To check if the game is paused
    private AudioSource backgroundAudio; // Reference to the background audio

    void Start()
    {
        // Get the AudioSource component (make sure your background music has an AudioSource)
        backgroundAudio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>(); // Adjust the tag or object if needed
        
        // Add listeners for buttons
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        pauseButton.onClick.AddListener(PauseGame); // Add listener for the Pause button
    }

    void Update()
    {
        // You can remove the escape key detection if you're using the Pause button to trigger it
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Pause the game (freeze all time-dependent actions)

        // Pause the background music
        if (backgroundAudio != null)
        {
            backgroundAudio.Pause();
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume the game (unfreeze time)

        // Resume the background music
        if (backgroundAudio != null)
        {
            backgroundAudio.UnPause();
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure game resumes before loading a new scene
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with your actual scene name
    }

    public void QuitGame()
    {
        // Quit the application or go back to the main menu
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
