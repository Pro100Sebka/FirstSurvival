using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValues : MonoBehaviour
{
    [SerializeField] Slider waterSlider;
    [SerializeField] Slider healthSlider;
    private float water;
    private float health;
    [SerializeField] private float waterMinus;
    private bool colided;
    
    private void Start()
    {
        water = 1f;
        health = 1f;
        colided = false;
        UpdateUI();
        StartCoroutine(WaterCoroutine());
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Water"))
        {
            Destroy(hit.gameObject);
            if (water <= 1f)
            {
                StartCoroutine(WaterAdd());
            }
        }

        if (hit.gameObject.CompareTag("Cactus"))
        {
            StartCoroutine(CactusColiding());
        }
    }


    private void UpdateUI()
    {
        waterSlider.value = water;
        healthSlider.value = health;
    }

    IEnumerator WaterCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            water -= 0.1f/waterMinus;
            UpdateUI();
        }
    }

    IEnumerator WaterAdd()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            water += 0.001f;
            UpdateUI();

        }
    }

    IEnumerator CactusColiding()
    {
        if (colided == false)
        {
            colided = true;
            for (int i = 0; i < 100; i++)
            {
                health -= 0.001f;
                UpdateUI();
                yield return new WaitForSeconds(0.001f);
            }
            colided = false;
        }

    }
    
}
