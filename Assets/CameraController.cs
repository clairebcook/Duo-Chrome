using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform cameraTarget;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowCameraTarget();
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
    
    // camera switch method
    public void changeMinMax(float minX, float maxX, float minY, float maxY) {
        xMin = minX;
        xMax = maxX;
        yMin = minY;
        yMax = maxY;
    }
}
