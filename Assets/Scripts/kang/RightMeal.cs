using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMeal : MonoBehaviour
{
    public GameObject ob;
    //Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            ob.GetComponent<HappinessManager>().happiness += 100;
            Debug.Log(ob.GetComponent<HappinessManager>().happiness);
    }
}
