using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipVideo : MonoBehaviour
{
    // Placeholder for the scene name


    public void Skipvideo()
    {
        if (!string.IsNullOrEmpty("scn_playscreen")) // Check if a scene name is provided
        {
            SceneManager.LoadScene("scn_playscreen");
        }
        else
        {
            Debug.LogWarning("No scene name provided in 'sceneToLoad'.");
        }
    }
}
