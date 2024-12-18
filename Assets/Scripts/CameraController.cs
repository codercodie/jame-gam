using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;         // The player object to follow
    public float cameraSpeed = 500f; // The speed at which the camera moves

    private Vector3 offset;          // Offset from the camera to the player

    void Start()
    {
        // Calculate the initial offset between the camera and the player
        offset = transform.position - player.position;
    }

    void Update()
    {
        // Move the camera to the right at a constant speed
        Vector3 newPosition = new Vector3(transform.position.x + cameraSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        // Apply the new camera position
        transform.position = newPosition;

    }
}
