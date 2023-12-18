using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValues : MonoBehaviour
{
    [SerializeField] Slider mainslider;
    private float water;

    [SerializeField] private float waterMinus;

    private void Start()
    {
        water = 1f;
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
    }

    private void UpdateUI()
    {
        mainslider.value = water;
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
    
    

 
}
