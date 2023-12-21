using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] Transform plrPos;
    [SerializeField] private Transform parent;

    private void Start()
    {
        for (int i = 0; i < Random.Range(25,50); i++) {
            Instantiate(cube,plrPos.position+new Vector3(Random.Range(-50,50),100,Random.Range(-50,50)),Quaternion.identity, parent);
        }
    }
}
