using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Fuck.");
        // Load the gameplay scene (replace "GameScene" with your gameplay scene's name)
        SceneManager.LoadScene("scn_originstory");
    }

    public void QuitGame()
    {
        // Quit the application (only works in a built executable)
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
