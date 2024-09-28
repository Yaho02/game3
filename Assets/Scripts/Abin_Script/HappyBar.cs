using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class HappyBar : MonoBehaviour
{
    [SerializeField]
    public Slider slStatus;
    float fSliderBarTime;
    public StatusData collect;

    void Start()
    {
        slStatus = GetComponent<Slider>();
        
    }

 
    void Update()
    {
        slStatus.value = collect.Happy;

    }
}
