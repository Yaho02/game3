using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject[] pages; // �� �������� ���� �迭
    public Gold_manager goldManager; // Gold_manager ��ũ��Ʈ ����
    public Text goldText; // ���� ��带 ǥ���ϴ� �ؽ�Ʈ

    private int currentPage = 0; // ���� ������ �ε���
    private int[] itemPrices = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200 }; // ��ǰ ���� ���

    void Start()
    {
        UpdateGoldDisplay();
        ShowPage(0); // ù ��° �������� ǥ��
    }

    // �������� �����ִ� �Լ�
    public void ShowPage(int pageIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == pageIndex); // ������ �������� Ȱ��ȭ
        }
        currentPage = pageIndex;
    }

    // ���� �������� �̵�
    public void NextPage()
    {
        int nextPage = (currentPage + 1) % pages.Length;
        ShowPage(nextPage);
    }

    // ���� �������� �̵�
    public void PreviousPage()
    {
        int prevPage = (currentPage - 1 + pages.Length) % pages.Length;
        ShowPage(prevPage);
    }

    // ������ ���� �Լ�
    public void BuyItem(int itemIndex)
    {
        int cost = itemPrices[itemIndex]; // �ش� ��ǰ�� ����

        if (goldManager.gold >= cost)
        {
            goldManager.DeductGold(cost); // Gold_manager�� ��带 ����
            UpdateGoldDisplay(); // UI ������Ʈ
            Debug.Log($"Item {itemIndex + 1}�� �����߽��ϴ�.");
        }
        else
        {
            Debug.Log("��尡 �����մϴ�.");
        }
    }
                
    // ��� UI�� ������Ʈ�ϴ� �Լ�
    private void UpdateGoldDisplay()
    {
        goldText.text = "Gold: " + goldManager.gold.ToString();
    }
}