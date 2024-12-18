using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Player Values")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount;
    public bool isMoving;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Game Management")]
    public GameManager gameManager;
    public GameObject gameOverBoundary;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = 0;
    }

    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        isMoving = Mathf.Abs(input) > 0.1f;
        rb.velocity = new Vector2(input * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && jumpCount < 1)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpCount++;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Reset jump count when grounded
        if (isGrounded)
        {
            jumpCount = 0;
        }
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == gameOverBoundary)
        {
            gameManager.GameOver();
        }
    }
}
