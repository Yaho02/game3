using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold_manager : MonoBehaviour
{
    public int gold; // ���� ������ �ִ� ���
    public int fee; // ������ ������
    public Text Gold1; // ���� ��带 ǥ���ϴ� �ؽ�Ʈ
    public Text Gold2; // �����Ḧ ǥ���ϴ� �ؽ�Ʈ

    // �Ƿ� ���(�������� ����)
    public void fee_amount()
    {
        fee = Random.Range(500, 2000);
        Debug.Log("������ fee: " + fee);
    }

    // ��ư�� ������ ��带 ȹ��
    public void getcoin()
    {
        gold = gold + fee;
        Debug.Log("ȹ��� gold: " + gold);
    }

    // ��� ����
    public void DeductGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            Debug.Log("Gold ���� �� ���� Gold: " + gold);
        }
        else
        {
            Debug.Log("��尡 �����մϴ�.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
        fee_amount(); // ������ ����
    }

    // Update is called once per frame
    void Update()
    {
        if (Gold1 != null)
        {
            Gold1.text = "GOLD : " + gold;
            Gold2.text = fee + " ��忡 ����";
        }
    }
}
