using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pika : MonoBehaviour
{
    public GameObject player1; // Player 1 ������Ʈ (�÷��̾�)
    public GameObject player2; // Player 2 ������Ʈ (AI)
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
    private float currentBallSpeed; // ���� �� �ӵ�
    private float speedIncreaseFactor = 0.2f; // �浹�� ������ �ӵ� ���� ����

    public float aiSpeed = 5f; // AI �̵� �ӵ�
    public float aiJumpForce = 12f; // AI ���� ��
    private float lastJumpTime = 0f; // AI�� ���������� ������ �ð�
    public float jumpCooldown = 1f;  // AI�� ������ �� �ִ� ���� (1��)

    public AudioSource hitSound;
    public AudioSource winSound;

    public UnityEngine.UI.Text player1ScoreText;
    public UnityEngine.UI.Text player2ScoreText;
    public UnityEngine.UI.Text resultText;

    private bool gameEnded = false;
    private const float scoreThreshold = -4.2f; // ������ ȹ���� �ٴ� ��ġ
    private const int maxScore = 50; // �ִ� ����
    private bool scoreGiven = false; // ���� ȹ�� ���� Ȯ��

    void Start()
    {
        // Rigidbody2D ������Ʈ�� �����ɴϴ�.
        player1Rb = player1.GetComponent<Rigidbody2D>();
        player2Rb = player2.GetComponent<Rigidbody2D>();
        ballRb = ball.GetComponent<Rigidbody2D>();

        // ���� ���� �ӵ��� �ʱ�ȭ
        currentBallSpeed = ballSpeed;

        // �ʱ� ��ġ ����
        ResetPositions();
        resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!gameEnded)
        {
            PlayerMovement();
            AIMovement(); // AI ������ ó��
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
    }

    void AIMovement()
    {
        float distanceToBallX = Mathf.Abs(ball.transform.position.x - player2.transform.position.x);
        float distanceToBallY = ball.transform.position.y - player2.transform.position.y;

        // ���� AI ������ �� �� X ��ǥ�� ���缭 �̵�
        if (ball.transform.position.x > net.transform.position.x) // ���� ��Ʈ�� �Ѿ� AI ������ �� ��
        {
            // ���� AI ������ X�� �Ÿ��� �ָ� ����
            if (distanceToBallX > 1.5f)
            {
                if (ball.transform.position.x > player2.transform.position.x)
                {
                    player2Rb.velocity = new Vector2(aiSpeed, player2Rb.velocity.y);
                }
                else if (ball.transform.position.x < player2.transform.position.x)
                {
                    player2Rb.velocity = new Vector2(-aiSpeed, player2Rb.velocity.y);
                }
            }

            // ���� AI�� ��ó�� �� �� ����, X��� Y�� ��� ���
            if (distanceToBallY > 1.0f && distanceToBallX < 3.0f && Time.time > lastJumpTime + jumpCooldown)
            {
                player2Rb.velocity = new Vector2(player2Rb.velocity.x, aiJumpForce); // AI�� ����
                lastJumpTime = Time.time; // ������ ���� �ð��� ���
            }
        }
        else
        {
            // ���� ��Ʈ �ݴ������� �� �� AI�� �������� ����
            player2Rb.velocity = new Vector2(0, player2Rb.velocity.y);
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
        // ������ �� ���� �����̸� 1�ʷ� ����
        yield return new WaitForSeconds(1.0f);

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
        currentBallSpeed = ballSpeed; // �� �ӵ��� �ʱ�ȭ
        ballRb.AddForce(new Vector2(Random.Range(-1f, 1f), 1f) * currentBallSpeed, ForceMode2D.Impulse);
    }

    // �浹�� ������ �ӵ��� ������Ű�� �Լ�
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� ��Ʈ, ��, �Ǵ� ĳ���Ϳ� �浹�� �� �ӵ� ����
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Net"))
        {
            currentBallSpeed += speedIncreaseFactor; // ���� �ӵ� ����
            ballRb.velocity = ballRb.velocity.normalized * currentBallSpeed; // �� �ӵ� ������Ʈ
        }
    }

    void UpdateScoreUI()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }
}
