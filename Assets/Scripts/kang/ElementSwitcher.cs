using UnityEngine;

public class ElementSwitcher : MonoBehaviour
{
    public GameObject[] elements; // UI 요소들을 배열로 저장
    private int currentPage = 0;   // 현재 페이지(3개 단위로 전환)
    private int itemsPerPage = 3;  // 페이지당 보여줄 요소 수

    void Start()
    {
        // 모든 요소를 숨기고 첫 번째 페이지만 보이도록 설정
        HideAllElements();
        ShowPage(currentPage);
    }

    // 페이지 전환 함수
    public void NextPage()
    {
        // 현재 페이지의 요소들을 숨김
        HidePage(currentPage);

        // 다음 페이지로 넘김. 마지막 페이지 이후에는 처음으로 돌아옴
        currentPage = (currentPage + 1) % (elements.Length / itemsPerPage);

        // 새 페이지의 요소들을 표시
        ShowPage(currentPage);
    }

    // 특정 페이지의 요소들을 표시하는 함수
    void ShowPage(int pageIndex)
    {
        // 페이지에 해당하는 요소들만 보이게 설정
        for (int i = 0; i < itemsPerPage; i++)
        {
            int elementIndex = pageIndex * itemsPerPage + i;
            if (elementIndex < elements.Length)
            {
                elements[elementIndex].SetActive(true);
            }
        }
    }

    // 특정 페이지의 요소들을 숨기는 함수
    void HidePage(int pageIndex)
    {
        // 페이지에 해당하는 요소들을 숨김
        for (int i = 0; i < itemsPerPage; i++)
        {
            int elementIndex = pageIndex * itemsPerPage + i;
            if (elementIndex < elements.Length)
            {
                elements[elementIndex].SetActive(false);
            }
        }
    }

    // 모든 요소를 숨기는 함수 (첫 페이지 외에 나머지 페이지 요소들 숨기기)
    void HideAllElements()
    {
        foreach (GameObject element in elements)
        {
            element.SetActive(false);
        }
    }
}