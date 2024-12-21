using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Speed Settings")]
    public float scrollSpeed = 2.0f;  // How fast the camera moves
    public bool startMoving = false;  // If the camera starts moving automatically
    public float stopPositionX = 192f; // The X position where the camera should stop moving

    void Update()
    {
        // Wait for the player to press D or release the right arrow key to start moving
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !startMoving)
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
}
