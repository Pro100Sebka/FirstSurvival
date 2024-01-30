using System;
using System.Collections;
using StarterAssets;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    private FirstPersonController fps;
    public bool walking;
    [SerializeField] private AudioSource _audioSource;
    private void Start()
    {
        fps = GetComponent<FirstPersonController>();
        _audioSource.Play();
        _audioSource.volume = 0f;
    }

    private void Update()
    {
        if (fps.speed > 0.1f)
        {
            if (walking == false)
            {
                walking = true;
                StartCoroutine(VolumeUp());
            }
        }
        else
        {
            if (walking)
            {
                walking = false;
                StartCoroutine(VolumeDown());
            }
        }
        
    }

    IEnumerator VolumeUp()
    {
        for (int i = 0; i < 100; i++)
        {
            if(!walking) yield break;
            _audioSource.volume += 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator VolumeDown()
    {
        
        for (int i = 0; i < 100; i++)
        {
            
            if(walking) yield break;
            _audioSource.volume -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
