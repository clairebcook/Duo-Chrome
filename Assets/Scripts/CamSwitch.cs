using UnityEngine;
// on collision with a player, the camera switch updates the camera min and maxes
public class CamSwitch : MonoBehaviour
{
    // camera settings
    public float cameraMinX;
    public float cameraMaxX;
    public float cameraMinY;
    public float cameraMaxY;
    private void OnCollisionEnter2D(Collision2D other) {
        var player = other.collider.GetComponent<Player1>();
        var cam = GetComponent<CameraController>();

        if (player != null) {
            cam.changeMinMax(cameraMinX, cameraMaxX, cameraMinY, cameraMaxY);
        }

    }
}
