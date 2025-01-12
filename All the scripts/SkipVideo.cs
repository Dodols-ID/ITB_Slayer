using UnityEngine;
using UnityEngine.SceneManagement;

// skip scene buat story-story before play screen
public class SkipVideo : MonoBehaviour
{
    public void Skipvideo()
    {
        if (!string.IsNullOrEmpty("scn_playscreen"))
        {
            SceneManager.LoadScene("scn_playscreen");
        }
        else
        {
            // kalau nama playscreen keganti
            Debug.LogWarning("No scene name provided in 'sceneToLoad'.");
        }
    }
}
