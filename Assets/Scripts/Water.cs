using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    public Slider mainslider;
    private float water;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Water"))
        {
            Destroy(hit.gameObject);
            if (water <= 1f)
            {
                water += 0.1f;
                mainslider.value = water;
            }
            
        }
    }
}
