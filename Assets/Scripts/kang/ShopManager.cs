using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject[] pages; // 각 페이지를 담을 배열
    public Gold_manager goldManager; // Gold_manager 스크립트 연결
    public Text goldText; // 현재 골드를 표시하는 텍스트

    private int currentPage = 0; // 현재 페이지 인덱스
    private int[] itemPrices = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200 }; // 상품 가격 목록

    void Start()
    {
        UpdateGoldDisplay();
        ShowPage(0); // 첫 번째 페이지를 표시
    }

    // 페이지를 보여주는 함수
    public void ShowPage(int pageIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == pageIndex); // 선택한 페이지만 활성화
        }
        currentPage = pageIndex;
    }

    // 다음 페이지로 이동
    public void NextPage()
    {
        int nextPage = (currentPage + 1) % pages.Length;
        ShowPage(nextPage);
    }

    // 이전 페이지로 이동
    public void PreviousPage()
    {
        int prevPage = (currentPage - 1 + pages.Length) % pages.Length;
        ShowPage(prevPage);
    }

    // 아이템 구매 함수
    public void BuyItem(int itemIndex)
    {
        int cost = itemPrices[itemIndex]; // 해당 상품의 가격

        if (goldManager.gold >= cost)
        {
            goldManager.DeductGold(cost); // Gold_manager의 골드를 차감
            UpdateGoldDisplay(); // UI 업데이트
            Debug.Log($"Item {itemIndex + 1}을 구매했습니다.");
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }
                
    // 골드 UI를 업데이트하는 함수
    private void UpdateGoldDisplay()
    {
        goldText.text = "Gold: " + goldManager.gold.ToString();
    }
}