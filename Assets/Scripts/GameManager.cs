using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image imageWakeUp;
    public Image damage;
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
    
    public IEnumerator Damage()
    {
        
        Color color = damage.color;
        
        color.a = 1f;
        damage.color = color;
        for (int i = 0; i < 100; i++)
        {
            color.a -= 0.01f;
            damage.color = color;
            yield return new WaitForSeconds(0.01f);
        }

    }
    



}
