using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusTest : MonoBehaviour
{
    public StatusData statusData;
    public TMP_Text Display;
    void Start()
    {
        statusData.Happy = 50;
        statusData.maxtime = 100;
        statusData.SaveStatus();
    }

    // Update is called once per frame
    void Update()
    {
        Display.text =
            "Time: " + statusData.maxtime + "\n" +
            "Happy: " + statusData.Happy + "\n" +
            "Damage : " + statusData.Damage;
    }
}
