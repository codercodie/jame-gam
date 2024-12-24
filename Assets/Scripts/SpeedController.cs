using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedController : MonoBehaviour
{
    public float speed;
    public static SpeedController Instance;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensure it persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        // Set initial speed based on the scene
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            speed = 2f;  // Set initial speed for the tutorial scene
        }
        else
        {
            speed = 1f;  // Set initial speed for the main game
        }

        Debug.Log("Initial Speed Set: " + speed);  // Log to confirm
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        Debug.Log("Speed updated to: " + speed);  // Log to confirm speed changes
    }
}
