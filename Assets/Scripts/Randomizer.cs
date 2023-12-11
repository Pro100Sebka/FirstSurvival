using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] int amount;

    private void Start()
    {
        for (int i = 0; i < amount; i++) {
            Instantiate(cube);
        }
    }
}
