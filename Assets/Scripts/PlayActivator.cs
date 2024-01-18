
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayActivator : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Scenes/Playground");
    }
    
}
