using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referensi menu pause
    public Button resumeButton; // referensi tombol 'resume'
    public Button mainMenuButton; // referensi tombol 'main menu'
    public Button pauseButton; // referensi tombol 'pause' yang ngebuka menu pause

    public bool isPaused = false; // flag untuk cek kalau game di pause atau nggak
    private AudioSource backgroundAudio; // referensi bgm

    void Start()
    {
        // Cari objek yang jadi sumber audio
        backgroundAudio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>(); // Adjust the tag or object if needed
        
        // Nambah listener ke source bgm
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        pauseButton.onClick.AddListener(PauseGame);
    }

    // Saat pause menu keluar
    public void PauseGame()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true); // Pause menu keluar
        Time.timeScale = 0f; // Game di pause (objek yang time dependent, mostly semua objek di game berhenti)

        // Bgm dimatiin sebentar
        if (backgroundAudio != null)
        {
            backgroundAudio.Pause();
        }
    }

    // Saat tombol resume di klik
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false); // Pause menu ditutup
        Time.timeScale = 1f; // Waktu dilanjutkan, objek permainan jalan lagi

        // Bgm dilanjutin dari poin terakhir dia berhenti
        if (backgroundAudio != null)
        {
            backgroundAudio.UnPause();
        }
    }

    // Kalau tombol main menu di klik
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Kembali ke main menu
    }
    // Kalau mau ada tombol quit
    public void QuitGame()
    {
        // Keluar aplikasinya
        Debug.Log("Quitting");
        Application.Quit();
    }
}
