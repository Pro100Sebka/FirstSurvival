using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene("Scenes/Playground");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}
