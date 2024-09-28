using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cc : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    public Transform spawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, foodPrefabs.Length);
        Instantiate(foodPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }
}