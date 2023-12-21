using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CactusSpawn : MonoBehaviour
{
    [SerializeField] private GameObject cactus;
    [SerializeField] private Transform parent;

    private void Start()
    {
        for (int i = 0; i < 1000; i++) {
            Instantiate(cactus,new Vector3(Random.Range(-1000,1000),50,Random.Range(-1000,1000)),cactus.transform.rotation,parent);
        }
        
    }
}
