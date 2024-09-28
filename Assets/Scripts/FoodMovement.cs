using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    //public float Speed = 0.7f;         // 음식을 이동시키는 속도
    public Transform endPoint;       // 음식이 도달할 지점

    void Start()
    {

    }

    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, endPoint.position, Speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, endPoint.position, 0.7f * Time.deltaTime);

        // 음식이 끝점에 도달하면 파괴
        /*if(Vector2.Distance(transform.position, endPoint.position) < 0.1f)
        {
            Destroy(gameObject);
        }*/
    }
}
