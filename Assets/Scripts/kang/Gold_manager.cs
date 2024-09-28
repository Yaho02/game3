using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold_manager : MonoBehaviour
{
    public int gold; // 현재 가지고 있는 골드
    public int fee; // 임의의 수수료
    public Text Gold1; // 현재 골드를 표시하는 텍스트
    public Text Gold2; // 수수료를 표시하는 텍스트

    // 의뢰 비용(랜덤으로 생성)
    public void fee_amount()
    {
        fee = Random.Range(500, 2000);
        Debug.Log("설정된 fee: " + fee);
    }

    // 버튼을 누르면 골드를 획득
    public void getcoin()
    {
        gold = gold + fee;
        Debug.Log("획득된 gold: " + gold);
    }

    // 골드 차감
    public void DeductGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            Debug.Log("Gold 차감 후 남은 Gold: " + gold);
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
        fee_amount(); // 수수료 설정
    }

    // Update is called once per frame
    void Update()
    {
        if (Gold1 != null)
        {
            Gold1.text = "GOLD : " + gold;
            Gold2.text = fee + " 골드에 수락";
        }
    }
}
