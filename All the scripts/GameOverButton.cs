using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    // Tombol - tombol yang ada di layar game over

    // Buat balik ke main menu
    public void MainMenu()
    {
        Time.timeScale = 1f; // Karena pas player mati time gamenya diberhentiin, dijalanin lagi
        SceneManager.LoadScene("scn_mainmenu"); // Terus pindah ke main menu
    }
    // Buat ngulang lagi gamenya
    public void RestartGame()
    {
        Time.timeScale = 1f; // Karena pas player mati time gamenya diberhentiin, dijalanin lagi
        SceneManager.LoadScene("scn_playscreen"); // Terus ulang lagi gamenya
    }
}