using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessAmount : MonoBehaviour
{
    public Text Happiness;
    public int hap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hap = FindObjectOfType<HappinessManager>().happiness;
        Happiness.text = "" + hap;
    }
}
