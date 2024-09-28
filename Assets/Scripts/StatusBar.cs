using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
   [SerializeField]
    private Slider slTimer;

    //public float MaxHp = 30;
    //public float CurHp = 30;


    //Slider slTimer;
    float fSliderBarTime;
    public int deletecount;
    void Start()
    {
        slTimer = GetComponent<Slider>();
    }
 
    void Update()
    {
        if (slTimer.value > 0.0f)
        {
            // 시간이 변경한 만큼 slider Value 변경을 합니다.
            slTimer.value -= Time.deltaTime*deletecount;
        }
        else
        {
            Debug.Log("Hunger is Zero.");
        }
    }
}
