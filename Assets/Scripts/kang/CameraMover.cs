using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float moveDistance = 500f; // X������ ������ �Ÿ� (�� UI�� ������ �Ÿ�)
    private Vector3 initialPosition; // ī�޶��� �ʱ� ��ġ ����
    private int currentTarget = 0; // ���� ī�޶� ���� �ִ� UI �ε���
    public int numberOfTargets = 9; // ī�޶� �̵��� UI ���� (�� UI ����)

    void Start()
    {
        // ī�޶��� �ʱ� ��ġ ����
        initialPosition = Camera.main.transform.position;
    }

    // ��ư�� ������ �� ȣ��� �Լ�
    public void MoveCamera()
    {
        // ī�޶� ������ UI ��Ҹ� ���� �ִٸ�, �ٽ� ó�� ��ġ�� �ǵ��ư�
        if (currentTarget < numberOfTargets - 1)
        {
            // X������ moveDistance��ŭ �̵� (���� UI ��Ҹ� ���߱� ����)
            Camera.main.transform.position += new Vector3(moveDistance, 0, 0);
            currentTarget++;
        }
        else
        {
            // ��� UI ��Ҹ� �� �ôٸ� ó�� ��ġ�� ���ư�
            Camera.main.transform.position = initialPosition;
            currentTarget = 0; // ó�� UI ��ҷ� ���ư�
        }
    }
}
