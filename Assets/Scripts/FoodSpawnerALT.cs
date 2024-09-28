using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnerALT : MonoBehaviour
{
    public GameObject[] foodPrefabs;  // 물, 불, 전기 음식 프리팹 배열
    public Transform spawnPoint;  // 음식이 생성되는 시작 지점
    public float spawnInterval = 1f;  // 음식 생성 간격
    private float endTime = 30f;  // 30초 동안 게임 진행
    private float time;
    private float wait;

    private void Start()
    {
        time = 0;
        wait = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;
        wait += Time.deltaTime;

        while (time < endTime)
        {
            if(wait > spawnInterval)
            {
                SpawnFood();
                wait = 0;
                spawnInterval = Random.Range(0.55f, 0.85f);
            }
        }
    }

    void SpawnFood()
    {
        int randomIndex = Random.Range(0, foodPrefabs.Length);
        GameObject foodObject = Instantiate(foodPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);

        //Food food = foodObject.GetComponent<Food>();
    }
}

