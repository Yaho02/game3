using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

using TMPro;
/// ui text를 불러오기 위한 부분

using JetBrains.Annotations;
public class Gold_manager : MonoBehaviour
{
    static int gold;
    static int fee;
    public Text Gold;

    // 의뢰 비용
    public void fee_amount()
    {
        fee = Random.Range(500, 2000);
        Debug.Log("설정된 fee: " + fee);
    }

    // 버튼 때면 골드 획득
    public void getcoin()
    {
        gold = gold + fee;
        Debug.Log("획득된 gold: " + gold);
    }

    // Start is called before the first frame update
    void Start()
    {
        gold = 0;
        fee_amount();

        // Gold가 에디터에서 제대로 할당되었는지 확인
        if (Gold != null)
        {
            Debug.Log("Gold 텍스트 오브젝트가 정상적으로 할당되었습니다.");
        }
        else
        {
            Debug.LogError("Gold 텍스트 오브젝트가 할당되지 않았습니다!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Gold != null)
        {
            Gold.text = "GOLD : " + gold;
        }
        else
        {
            Debug.LogError("Gold 텍스트가 null입니다. UI 텍스트가 할당되지 않았습니다.");
        }
    }
}
