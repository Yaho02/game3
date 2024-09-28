using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

using TMPro;
/// ui text¸¦ ºÒ·¯¿À±â À§ÇÑ ºÎºÐ

using JetBrains.Annotations;
public class Gold_manager : MonoBehaviour
{
    static int gold;
    static int fee;
    public Text Gold1;
    public Text Gold2;

    // ÀÇ·Ú ºñ¿ë
    public void fee_amount()
    {
        fee = Random.Range(500, 2000);
        Debug.Log("¼³Á¤µÈ fee: " + fee);
    }

    // ¹öÆ° ¶§¸é °ñµå È¹µæ
    public void getcoin()
    {
        gold = gold + fee;
        Debug.Log("È¹µæµÈ gold: " + gold);
    }


    // Start is called before the first frame update
    void Start()
    {
        gold = 0;
        fee_amount();


    }

    // Update is called once per frame
    void Update()
    {
        if (Gold1 != null)
        {
            Gold1.text = "GOLD : " + gold;
            Gold2.text =  fee + " °ñµå¿¡ ¼ö¶ô";

        }
        
    
    }
}
