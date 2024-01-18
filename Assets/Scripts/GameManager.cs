using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image imageWakeUp;
    private void Start()
    {
        StartCoroutine(WakeUpCoroutine());
    }
    
    private IEnumerator WakeUpCoroutine()
    {
        Color color = imageWakeUp.color;
        for (int i = 0; i < 100; i++)
        {
            color.a -= 0.01f;
            imageWakeUp.color = color;
            yield return new WaitForSeconds(0.01f);
        }

    }
    
    
    
}
