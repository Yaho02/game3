using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

using TMPro;
/// ui text�� �ҷ����� ���� �κ�

using JetBrains.Annotations;
public class Gold_manager : MonoBehaviour
{
    static int gold;
    static int fee;
    public Text Gold;

    // �Ƿ� ���
    public void fee_amount()
    {
        fee = Random.Range(500, 2000);
        Debug.Log("������ fee: " + fee);
    }

    // ��ư ���� ��� ȹ��
    public void getcoin()
    {
        gold = gold + fee;
        Debug.Log("ȹ��� gold: " + gold);
    }

    // Start is called before the first frame update
    void Start()
    {
        gold = 0;
        fee_amount();

        // Gold�� �����Ϳ��� ����� �Ҵ�Ǿ����� Ȯ��
        if (Gold != null)
        {
            Debug.Log("Gold �ؽ�Ʈ ������Ʈ�� ���������� �Ҵ�Ǿ����ϴ�.");
        }
        else
        {
            Debug.LogError("Gold �ؽ�Ʈ ������Ʈ�� �Ҵ���� �ʾҽ��ϴ�!");
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
            Debug.LogError("Gold �ؽ�Ʈ�� null�Դϴ�. UI �ؽ�Ʈ�� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
}
