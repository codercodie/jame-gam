using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed;
    public bool startMoving = false;
    public float stopPositionX = 192f;
    public SpeedController speedController;
    

    public void Start()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            stopPositionX = 0f;
        }
        speedController = GameObject.Find("SpeedController").GetComponent<SpeedController>();
        scrollSpeed = speedController.speed;

        if (scrollSpeed == 0f)
        {
            scrollSpeed = 2f;
        }

        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            scrollSpeed = 0.5f;
        }

        
    }
    void Update()
    {

        scrollSpeed = speedController.speed;
        if (scrollSpeed == 0f)
        {
            scrollSpeed = 2f;
        }
        // Wait for the player to press D or release the right arrow key to start moving
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !startMoving)
        {
            startMoving = true;  // Start moving the camera once the key is pressed
        }

        if (startMoving)
        {
            // Check if the camera's position is less than stopPositionX
            if (transform.position.x < stopPositionX)
            {
                // Move the camera horizontally over time
                transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
            }
            else
            {
                // Stop the camera once it reaches or exceeds stopPositionX
                transform.position = new Vector3(stopPositionX, transform.position.y, transform.position.z);
            }
        }
    }

    public void SetSpeed(float speed)
    {
        scrollSpeed = speed;
    }
}
