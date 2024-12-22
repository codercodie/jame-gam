using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private bool isGameOver; // Add this flag

    [Header("Ground Detection")]
    public Transform groundCheck;
    public LayerMask groundLayer, houseLayer;

    [Header("Game Management")]
    public GameManager gameManager;
    public GameObject gameOverBoundary;
    public Animator anim;
    public AudioManager audioManager;
    public CameraController cameraController;

    void Start()
    {
        jumpCount = 0;
        isMoving = false;
        isJumping = false;
        facingLeft = false;
        facingRight = true;
        isGameOver = false; // Initialize the flag
        anim.SetBool("IsJumping", isJumping);
        anim.SetBool("IsWalking", isMoving);
        anim.SetBool("facingLeft", facingLeft);
        anim.SetBool("facingRight", facingRight);

        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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

        // Clamp the player's position to prevent moving off the right side
        ClampPlayerPosition();

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

        // Check if the player is off the left side of the screen
        CheckIfOffCamera();
    }

    void Jump()
    {
        // Apply the jump force to the Rigidbody2D
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpCount++;
        isJumping = true;
        audioManager.PlaySFX(7);
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

    private void CheckIfOffCamera()
    {
        // Get player's viewport position
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

      
        // Check if player is off the left side of the screen
        if (viewportPosition.x < 0 && !isGameOver && SceneManager.GetActiveScene().name == "Game") // Ensure GameOver is called only once and not in tutorial mode
        {
            Debug.Log("Player went off the left side of the screen!");
            isGameOver = true; // Set the flag to prevent further calls
            gameManager.GameOver();
        }
        if (viewportPosition.x < 0 && SceneManager.GetActiveScene().name == "Tutorial")
        {
            cameraController.startMoving = false;
        }

    }

    private void ClampPlayerPosition()
    {
        // Get the camera bounds
        Vector3 screenRightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
        Vector3 screenLeftEdge = Camera.main.ViewportToWorldPoint(new Vector3(-1, 0, 0));

        // Prevent the player from moving off the right side of the screen
        if (transform.position.x > screenRightEdge.x)
        {
            transform.position = new Vector3(screenRightEdge.x, transform.position.y, transform.position.z);
        }

        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            // Prevent the player from moving off the left side of the screen
            if (transform.position.x > screenLeftEdge.x)
            {
                transform.position = new Vector3(screenRightEdge.x, transform.position.y, transform.position.z);
            }
        }
    }

    public bool IsMoving()
    {
        return isMoving;
    }
}
