using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGameManager : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private AudioSource clickSound;
    private MeshRenderer rb;

    public void InfoTriger()
    {
        clickSound.Play();
        if (infoPanel.gameObject.activeInHierarchy)
        {
            infoPanel.gameObject.SetActive(false);
        }
        else
        {
            infoPanel.gameObject.SetActive(true);
        }
    }
    public void SettingsTriger()
    {
        clickSound.Play();
        if (settingsPanel.gameObject.activeInHierarchy)
        {
            settingsPanel.gameObject.SetActive(false);
        }
        else
        {
            settingsPanel.gameObject.SetActive(true);
        }
    }
}
