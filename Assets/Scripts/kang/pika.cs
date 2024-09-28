using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pika : MonoBehaviour
{
    public GameObject player1; // Player 1 오브젝트
    public GameObject player2; // Player 2 오브젝트
    public GameObject ball;    // 공 오브젝트
    public GameObject net;     // 네트 오브젝트
    public Transform player1StartPos;
    public Transform player2StartPos;
    public Transform ballStartPos;

    private Rigidbody2D player1Rb;
    private Rigidbody2D player2Rb;
    private Rigidbody2D ballRb;

    public int player1Score = 0;
    public int player2Score = 0;

    public float playerSpeed = 7f;
    public float ballSpeed = 5f;

    public AudioSource hitSound;
    public AudioSource winSound;

    public UnityEngine.UI.Text player1ScoreText;
    public UnityEngine.UI.Text player2ScoreText;
    public UnityEngine.UI.Text resultText;

    private bool gameEnded = false;
    private const float scoreThreshold = -4.2f; // 점수를 획득할 바닥 위치
    private const int maxScore = 10; // 최대 점수
    private bool scoreGiven = false; // 점수 획득 여부 확인

    void Start()
    {
        // Rigidbody2D 컴포넌트를 가져옵니다.
        player1Rb = player1.GetComponent<Rigidbody2D>();
        player2Rb = player2.GetComponent<Rigidbody2D>();
        ballRb = ball.GetComponent<Rigidbody2D>();

        // 초기 위치 설정
        ResetPositions();
        resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!gameEnded)
        {
            PlayerMovement();
            CheckGameStatus();
        }
    }

    void PlayerMovement()
    {
        // 플레이어 1 이동
        if (Input.GetKey(KeyCode.A))
        {
            player1Rb.velocity = new Vector2(-playerSpeed, player1Rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player1Rb.velocity = new Vector2(playerSpeed, player1Rb.velocity.y);
        }
        else
        {
            player1Rb.velocity = new Vector2(0, player1Rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player1Rb.velocity = new Vector2(player1Rb.velocity.x, 15f); // 점프
        }

        // 플레이어 2 이동
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player2Rb.velocity = new Vector2(-playerSpeed, player2Rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            player2Rb.velocity = new Vector2(playerSpeed, player2Rb.velocity.y);
        }
        else
        {
            player2Rb.velocity = new Vector2(0, player2Rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            player2Rb.velocity = new Vector2(player2Rb.velocity.x, 15f); // 점프
        }
    }

    void CheckGameStatus()
    {
        // 공이 -4.2보다 낮은 위치로 떨어질 때 점수를 계산 (한 번만 점수 부여)
        if (ball.transform.position.y < scoreThreshold && !scoreGiven)
        {
            scoreGiven = true; // 점수는 한 번만 주기 위해 플래그 설정

            if (ball.transform.position.x < net.transform.position.x)
            {
                player2Score++; // Player 2 득점
            }
            else
            {
                player1Score++; // Player 1 득점
            }

            StartCoroutine(ResetGameWithDelay()); // 점수 후 초기화
        }

        // 공이 다시 위로 올라가면 점수 획득 가능 상태로 변경
        if (ball.transform.position.y > scoreThreshold)
        {
            scoreGiven = false;
        }

        UpdateScoreUI();

        if (player1Score >= maxScore)
        {
            gameEnded = true;
            resultText.gameObject.SetActive(true);
            resultText.text = "Player 1 Wins!";
            winSound.Play();
        }
        else if (player2Score >= maxScore)
        {
            gameEnded = true;
            resultText.gameObject.SetActive(true);
            resultText.text = "Player 2 Wins!";
            winSound.Play();
        }
    }

    // 점수는 유지하면서 공과 플레이어의 위치를 초기화
    IEnumerator ResetGameWithDelay()
    {
        // 약간의 딜레이 추가 (2초)
        yield return new WaitForSeconds(2.0f);

        ResetPositions(); // 공과 플레이어의 위치를 초기화
    }

    void ResetPositions()
    {
        // 공과 플레이어의 위치를 초기화
        ball.transform.position = ballStartPos.position;
        player1.transform.position = player1StartPos.position;
        player2.transform.position = player2StartPos.position;

        // 공과 플레이어의 속도를 0으로 설정
        ballRb.velocity = Vector2.zero;
        player1Rb.velocity = Vector2.zero;
        player2Rb.velocity = Vector2.zero;

        // 공의 초기 속도 설정 (속도도 초기화)
        ballRb.AddForce(new Vector2(Random.Range(-1f, 1f), 1f) * ballSpeed, ForceMode2D.Impulse);
    }

    void UpdateScoreUI()
    {
        player1ScoreText.text = "P1 score : " + player1Score.ToString();
        player2ScoreText.text = "P2 score : " + player2Score.ToString();
    }
}
