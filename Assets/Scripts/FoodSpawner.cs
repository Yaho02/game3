using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs;  // 물, 불, 전기 음식 프리팹 배열
    public Transform spawnPoint;  // 음식이 생성되는 시작 지점
    public float spawnInterval = 1f;  // 음식 생성 간격
    private float endTime = 300f;  // 30초 동안 게임 진행
    //private float time;
    private int cnt;

    private void Start()
    {
        StartCoroutine(SpawnFood());
        //time = 0;
        cnt = 0;
    }

    IEnumerator SpawnFood()
    {
        while(cnt < 30)
        {
            SpawnRandomFood();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomFood()
    {
        int randomIndex = Random.Range(0, foodPrefabs.Length);
        GameObject foodObject = Instantiate(foodPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
        cnt++;

        //Food food = foodObject.GetComponent<Food>();

        spawnInterval = Random.Range(0.55f, 0.85f);
    }
}
