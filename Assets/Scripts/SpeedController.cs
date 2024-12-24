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
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // If another instance exists, destroy this one
        }

        // Initially set the speed based on the current scene
        UpdateSpeedForScene();

        // Register the scene loaded event to update speed when scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnEnable()
    {
        // Re-register the scene loaded event in case the object is re-enabled
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe to avoid multiple registrations
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Method to update speed when scene changes
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateSpeedForScene();  // Update the speed based on the new scene
    }

    private void UpdateSpeedForScene()
    {
        // Get the current scene name
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Current scene: " + sceneName);

        // Set speed based on the scene
        if (sceneName == "Tutorial")
        {
            speed = 1f;  // Speed for tutorial
        }
        else
        {
            speed = 2f;  // Speed for main game
        }

        Debug.Log("Speed set for " + sceneName + ": " + speed);  // Log the speed value
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        Debug.Log("Speed updated to: " + speed);  // Log to confirm speed changes
    }
}
