using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Speed Settings")]
    public float scrollSpeed = 2.0f;  // How fast the camera moves
    public bool startMoving = true;  // If the camera starts moving automatically

    void Update()
    {
        if (startMoving)
        {
            // Move the camera horizontally over time
            transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
        }
    }
}
