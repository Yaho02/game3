using UnityEngine;

public class ElementSwitcher : MonoBehaviour
{
    public GameObject[] elements; // UI ��ҵ��� �迭�� ����
    private int currentPage = 0;   // ���� ������(3�� ������ ��ȯ)
    private int itemsPerPage = 3;  // �������� ������ ��� ��

    void Start()
    {
        // ��� ��Ҹ� ����� ù ��° �������� ���̵��� ����
        HideAllElements();
        ShowPage(currentPage);
    }

    // ������ ��ȯ �Լ�
    public void NextPage()
    {
        // ���� �������� ��ҵ��� ����
        HidePage(currentPage);

        // ���� �������� �ѱ�. ������ ������ ���Ŀ��� ó������ ���ƿ�
        currentPage = (currentPage + 1) % (elements.Length / itemsPerPage);

        // �� �������� ��ҵ��� ǥ��
        ShowPage(currentPage);
    }

    // Ư�� �������� ��ҵ��� ǥ���ϴ� �Լ�
    void ShowPage(int pageIndex)
    {
        // �������� �ش��ϴ� ��ҵ鸸 ���̰� ����
        for (int i = 0; i < itemsPerPage; i++)
        {
            int elementIndex = pageIndex * itemsPerPage + i;
            if (elementIndex < elements.Length)
            {
                elements[elementIndex].SetActive(true);
            }
        }
    }

    // Ư�� �������� ��ҵ��� ����� �Լ�
    void HidePage(int pageIndex)
    {
        // �������� �ش��ϴ� ��ҵ��� ����
        for (int i = 0; i < itemsPerPage; i++)
        {
            int elementIndex = pageIndex * itemsPerPage + i;
            if (elementIndex < elements.Length)
            {
                elements[elementIndex].SetActive(false);
            }
        }
    }

    // ��� ��Ҹ� ����� �Լ� (ù ������ �ܿ� ������ ������ ��ҵ� �����)
    void HideAllElements()
    {
        foreach (GameObject element in elements)
        {
            element.SetActive(false);
        }
    }
}