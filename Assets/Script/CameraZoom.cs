using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera targetCamera;             // Reference to the camera object
    public Transform followTarget;          // GameObject the camera should follow
    public float zoomSpeed = 5f;            // Adjust the speed of zoom
    public float minZoom = 2f;              // Minimum zoom level
    public float maxZoom = 40f;             // Maximum zoom level
    public Vector3 offset = new Vector3(0, 0, 0); // Offset to keep the camera behind the target

    private float targetZoom;               // Target zoom level

    void Start()
    {
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }

        // Initialize targetZoom with the current zoom level
        targetZoom = targetCamera.orthographicSize;
    }

    void Update()
    {
        // Check for zoom in/out input with '[' and ']' keys
        if (Input.GetKey(KeyCode.RightBracket))
        {
            targetZoom -= zoomSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftBracket))
        {
            targetZoom += zoomSpeed * Time.deltaTime;
        }

        // Clamp the target zoom level between min and max
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);

        // Smoothly interpolate the camera's zoom level towards the target zoom level
        targetCamera.orthographicSize = Mathf.Lerp(targetCamera.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);

        // Make the camera follow the assigned target
        if (followTarget != null)
        {
            targetCamera.transform.position = followTarget.position + offset;
        }
    }
}
