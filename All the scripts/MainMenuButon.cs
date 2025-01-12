using UnityEngine;
using UnityEngine.SceneManagement;

// tombol - tombol main menu
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load scene buat cinematic sebelum play screen
        SceneManager.LoadScene("scn_originstory");
    }

    public void QuitGame()
    {
        // Keluar game
        Debug.Log("Quitting.");
        Application.Quit();
    }
}
