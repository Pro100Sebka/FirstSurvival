using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerValues : MonoBehaviour
{
    [SerializeField] Slider waterSlider;
    [SerializeField] Slider healthSlider;
    private float water;
    private float health;
    [SerializeField] private float waterMinus;
    [SerializeField] private int damageColdoown;
    private bool colided;
    private bool canTakeDamage;
    private GameManager _gameManager;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource damageSound;
    [SerializeField] private GameObject dieScreen;
    
    private void Start()
    {
        water = 1f;
        health = 1f;
        colided = false;
        canTakeDamage = true;
        UpdateUI();
        StartCoroutine(WaterCoroutine());
        _gameManager = FindObjectOfType<GameManager>();
        dieScreen.gameObject.SetActive(false);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Water"))
        {
            _audioSource.Play();
            Destroy(hit.gameObject);
            StartCoroutine(WaterAdd());
            
        }

        if (hit.gameObject.CompareTag("Cactus"))
        {
            if (canTakeDamage)
            {
                StartCoroutine(GettingDamage());
                StartCoroutine(_gameManager.Damage());
                damageSound.Play();
            }
        }
    }


    private void UpdateUI()
    {
        waterSlider.value = water;
        healthSlider.value = health;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

    IEnumerator WaterCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (water>=0.1f/waterMinus)
            {
                water -= 0.1f/waterMinus;
                UpdateUI();
            }
            if (water <= 0)
            {
                if (canTakeDamage)
                {
                    StartCoroutine(GettingDamage());
                }
            }
        }
    }

    IEnumerator WaterAdd()
    {
        for (int i = 0; i < 100; i++)
        {
            if (water <= 1f)
            {
                yield return new WaitForSeconds(0.01f);
                water += 0.001f;
                UpdateUI();
            }
            else yield break;
            
        }
    }

    IEnumerator GettingDamage()
    {
        canTakeDamage = false;
        if (health >=0)
        {
            health -= 0.1f;
            UpdateUI();
        }
        else
        {
            dieScreen.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(damageColdoown);
        canTakeDamage = true;
        
    }

}
