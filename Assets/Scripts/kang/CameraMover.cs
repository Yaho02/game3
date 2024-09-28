using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float moveDistance = 500f; // X축으로 움직일 거리 (각 UI가 떨어진 거리)
    private Vector3 initialPosition; // 카메라의 초기 위치 저장
    private int currentTarget = 0; // 현재 카메라가 보고 있는 UI 인덱스
    public int numberOfTargets = 9; // 카메라가 이동할 UI 개수 (총 UI 개수)

    void Start()
    {
        // 카메라의 초기 위치 저장
        initialPosition = Camera.main.transform.position;
    }

    // 버튼을 눌렀을 때 호출될 함수
    public void MoveCamera()
    {
        // 카메라가 마지막 UI 요소를 보고 있다면, 다시 처음 위치로 되돌아감
        if (currentTarget < numberOfTargets - 1)
        {
            // X축으로 moveDistance만큼 이동 (다음 UI 요소를 비추기 위해)
            Camera.main.transform.position += new Vector3(moveDistance, 0, 0);
            currentTarget++;
        }
        else
        {
            // 모든 UI 요소를 다 봤다면 처음 위치로 돌아감
            Camera.main.transform.position = initialPosition;
            currentTarget = 0; // 처음 UI 요소로 돌아감
        }
    }
}
