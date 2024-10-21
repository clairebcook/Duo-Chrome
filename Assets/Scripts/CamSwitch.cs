using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public Vector3 staticPosition;
    public float zoomLevel = 5f;

    public CameraController camController; 

    void Start()
    {
        if (camController == null)
        {
            camController = Camera.main.GetComponent<CameraController>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();

        if (player != null && camController != null)
        {
        
            camController.SetStaticPosition(staticPosition, zoomLevel);

        }
    }
}
