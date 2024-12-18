using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Player Values")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount;
    public bool isMoving;
    public bool isJumping;
    public bool facingLeft;
    public bool facingRight;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public LayerMask groundLayer, houseLayer;

    [Header("Game Management")]
    public GameManager gameManager;
    public GameObject gameOverBoundary;
    public Animator anim;

    void Start()
    {
        jumpCount = 0;
        isMoving = false;
        isJumping = false;
        facingLeft = false;
        facingRight = true;
        anim.SetBool("IsJumping", isJumping);
        anim.SetBool("IsWalking", isMoving);
        anim.SetBool("facingLeft", facingLeft);
        anim.SetBool("facingRight", facingRight);
    }

    void Update()
    {
        // Get the horizontal input for movement
        float input = Input.GetAxisRaw("Horizontal");
        isMoving = Mathf.Abs(input) > 0.1f;

        // Set facing direction based on input
        if (input > 0) // Moving right
        {
            facingLeft = false;
            facingRight = true;
        }
        else if (input < 0) // Moving left
        {
            facingLeft = true;
            facingRight = false;
        }

        // Apply horizontal movement velocity
        rb.velocity = new Vector2(input * moveSpeed, rb.velocity.y);

        // Trigger the jump
        if (Input.GetButtonDown("Jump") && jumpCount < 1)
        {
            Jump();
        }

        // Update animator parameters
        anim.SetBool("IsJumping", isJumping);
        anim.SetBool("IsWalking", isMoving);
        anim.SetBool("facingLeft", facingLeft);
        anim.SetBool("facingRight", facingRight);
    }

    void Jump()
    {
        // Apply the jump force to the Rigidbody2D
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpCount++;
        isJumping = true;
    }

    void FixedUpdate()
    {
        // Check if player is grounded, considering both groundLayer and houseLayer
        bool isOnGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        bool isOnHouse = Physics2D.OverlapCircle(groundCheck.position, 0.1f, houseLayer);

        // Player is grounded if they are touching either the groundLayer or houseLayer
        isGrounded = isOnGround || isOnHouse;

        // If the player is grounded, reset jump state
        if (isGrounded)
        {
            if (isJumping) // Only reset if previously jumping
            {
                isJumping = false; // Reset jump state
            }
            jumpCount = 0; // Reset jump count for future jumps
        }
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player collides with game over boundary
        if (collision.gameObject == gameOverBoundary)
        {
            gameManager.GameOver();
        }
    }
}
