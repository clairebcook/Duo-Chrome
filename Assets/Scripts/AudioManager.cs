using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Music Source----------")]
    public AudioClip death;
    public AudioClip door;
    public AudioClip colorFlip;
    public AudioClip dash;
    public AudioClip jump;

    private AudioSource audioController;
    
    void Start () {
        audioController = GetComponent<AudioSource>();
    }
    
    public void playDeath() {
        audioController.PlayOneShot(death);
    }

        public void playDoor() {
        audioController.PlayOneShot(door);
    }

    public void playFlip() {
        audioController.PlayOneShot(colorFlip);
    }

    public void playDash() {
        audioController.PlayOneShot(dash);
    }

    public void playJump() {
        audioController.PlayOneShot(jump);
    }

}
