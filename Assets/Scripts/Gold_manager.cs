using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Gold_manager : MonoBehaviour { 

    static int gold = 0;

    public static void setGold(int value)
    {
        gold += value;
    }

    public static int getGold()
    {
        return gold;

    }
    void OnGUI()
    {
        GUILayout.Label("GOLD : " + gold.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
