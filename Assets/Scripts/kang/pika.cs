using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pika : MonoBehaviour
{
    public GameObject player1; // Player 1 ������Ʈ
    public GameObject player2; // Player 2 ������Ʈ
    public GameObject ball;    // �� ������Ʈ
    public GameObject net;     // ��Ʈ ������Ʈ
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
    private const float scoreThreshold = -4.2f; // ������ ȹ���� �ٴ� ��ġ
    private const int maxScore = 10; // �ִ� ����
    private bool scoreGiven = false; // ���� ȹ�� ���� Ȯ��

    void Start()
    {
        // Rigidbody2D ������Ʈ�� �����ɴϴ�.
        player1Rb = player1.GetComponent<Rigidbody2D>();
        player2Rb = player2.GetComponent<Rigidbody2D>();
        ballRb = ball.GetComponent<Rigidbody2D>();

        // �ʱ� ��ġ ����
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
        // �÷��̾� 1 �̵�
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
            player1Rb.velocity = new Vector2(player1Rb.velocity.x, 15f); // ����
        }

        // �÷��̾� 2 �̵�
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
            player2Rb.velocity = new Vector2(player2Rb.velocity.x, 15f); // ����
        }
    }

    void CheckGameStatus()
    {
        // ���� -4.2���� ���� ��ġ�� ������ �� ������ ��� (�� ���� ���� �ο�)
        if (ball.transform.position.y < scoreThreshold && !scoreGiven)
        {
            scoreGiven = true; // ������ �� ���� �ֱ� ���� �÷��� ����

            if (ball.transform.position.x < net.transform.position.x)
            {
                player2Score++; // Player 2 ����
            }
            else
            {
                player1Score++; // Player 1 ����
            }

            StartCoroutine(ResetGameWithDelay()); // ���� �� �ʱ�ȭ
        }

        // ���� �ٽ� ���� �ö󰡸� ���� ȹ�� ���� ���·� ����
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

    // ������ �����ϸ鼭 ���� �÷��̾��� ��ġ�� �ʱ�ȭ
    IEnumerator ResetGameWithDelay()
    {
        // �ణ�� ������ �߰� (2��)
        yield return new WaitForSeconds(2.0f);

        ResetPositions(); // ���� �÷��̾��� ��ġ�� �ʱ�ȭ
    }

    void ResetPositions()
    {
        // ���� �÷��̾��� ��ġ�� �ʱ�ȭ
        ball.transform.position = ballStartPos.position;
        player1.transform.position = player1StartPos.position;
        player2.transform.position = player2StartPos.position;

        // ���� �÷��̾��� �ӵ��� 0���� ����
        ballRb.velocity = Vector2.zero;
        player1Rb.velocity = Vector2.zero;
        player2Rb.velocity = Vector2.zero;

        // ���� �ʱ� �ӵ� ���� (�ӵ��� �ʱ�ȭ)
        ballRb.AddForce(new Vector2(Random.Range(-1f, 1f), 1f) * ballSpeed, ForceMode2D.Impulse);
    }

    void UpdateScoreUI()
    {
        player1ScoreText.text = "P1 score : " + player1Score.ToString();
        player2ScoreText.text = "P2 score : " + player2Score.ToString();
    }
}
