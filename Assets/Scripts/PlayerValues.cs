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
    [SerializeField] private int damageColdoown;
    private bool colided;
    private bool canTakeDamage;
    private GameManager _gameManager;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource damageSound;
    
    private void Start()
    {
        water = 1f;
        health = 1f;
        colided = false;
        canTakeDamage = true;
        UpdateUI();
        StartCoroutine(WaterCoroutine());
        _gameManager = FindObjectOfType<GameManager>();

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Water"))
        {
            _audioSource.Play();
            Destroy(hit.gameObject);
            if (water <= 1f)
            {
                StartCoroutine(WaterAdd());
            }
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

    IEnumerator GettingDamage()
    {
        canTakeDamage = false;
        
        health -= 0.1f;
        UpdateUI();
        yield return new WaitForSeconds(damageColdoown);
        canTakeDamage = true;

    }

}
