using System.Collections;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private Transform sunTransform;

    private void Start()
    {
        StartCoroutine(DayCycle());
    }


    IEnumerator DayCycle()
    {
        Vector3 lightingRotation = sunTransform.rotation.eulerAngles;
        while (true)
        {
            lightingRotation.x += 1;
            sunTransform.rotation = Quaternion.Euler(lightingRotation);
            yield return new WaitForSeconds(1);
        }
    }
}