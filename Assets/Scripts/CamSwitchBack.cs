using UnityEngine;

// On trigger with a player, the camera switches between static and dynamic positions
public class CamSwitchBack : MonoBehaviour
{

    public CameraController camController; 


    void Start()
    {
        if (camController == null)
        {
            camController = Camera.main.GetComponent<CameraController>();
        }
    }

    // Use OnTriggerEnter2D to switch between static and dynamic positions when the player enters the trigger area
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player1>();

        if (player != null && camController != null)
        {
        
            camController.ResumeFollowing();

        }
    }
}
