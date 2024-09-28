using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappyBar : MonoBehaviour
{
    Slider slStatus;
    float fSliderBarTime;
    public int ccount;

    GameObject obj;
    void Start()
    {
        slStatus = GetComponent<Slider>();
        obj = GameObject.Find("Time Slider");
    }
 
    void Update()
    {
        slStatus.value += ccount;

        if (slStatus.value > 40.0f)
        {
            //a = obj.GetComponent<StatusBar>.slTimer;
        }
        else
        {
            Debug.Log("Unhappy. GameOver");
        }
    }
}
