using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTarget;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public Camera cam;
    private bool followTarget = true; 
    private float defaultZoomLevel;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam != null)
        {
            defaultZoomLevel = cam.orthographicSize; // Store the default zoom level when the camera starts
        }
    }

    void Update()
    {
        if (followTarget)
        {
            FollowCameraTarget();
        }
    }

    public void FollowCameraTarget()
    {
        Vector3 targetPosition = transform.position;

        if (targetPosition.x - cameraTarget.position.x < 0 && targetPosition.x < xMax)
        {
            if (cameraTarget.position.x > xMax) targetPosition.x = xMax;
            else targetPosition.x = cameraTarget.position.x;
        }
        if (cameraTarget.position.x - targetPosition.x < 0 && targetPosition.x > xMin)
        {
            if (cameraTarget.position.x < xMin) targetPosition.x = xMin;
            else targetPosition.x = cameraTarget.position.x;
        }
        if (targetPosition.y - cameraTarget.position.y < 0 && targetPosition.y < yMax)
        {
            if (cameraTarget.position.y > yMax) targetPosition.y = yMax;
            else targetPosition.y = cameraTarget.position.y;
        }
        if (cameraTarget.position.y - targetPosition.y < 0 && targetPosition.y > yMin)
        {
            if (cameraTarget.position.y < yMin) targetPosition.y = yMin;
            else targetPosition.y = cameraTarget.position.y;
        }

        transform.position = targetPosition;
    }

    // Method to switch camera bounds
    public void changeMinMax(float minX, float maxX, float minY, float maxY)
    {
        xMin = minX;
        xMax = maxX;
        yMin = minY;
        yMax = maxY;
    }

    // Method to move the camera to a static position and stop following
    public void SetStaticPosition(Vector3 position, float zoomLevel)
    {
        followTarget = false; 
        transform.position = new Vector3(position.x, position.y, transform.position.z); 

        // Adjust the zoom level 
        if (cam != null)
        {
            cam.orthographicSize = zoomLevel;
        }
    }

    // Method to resume following the camera target and reset zoom level
    public void ResumeFollowing()
    {
        followTarget = true;

        if (cam != null)
        {
            cam.orthographicSize = defaultZoomLevel;
        }
    }
}
