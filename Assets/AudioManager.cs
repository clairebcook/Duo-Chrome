using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Source---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------Music Source----------")]
    public AudioClip death;
    public AudioClip door;
    public AudioClip checkpoint;
    public AudioClip colorFlip;
    public AudioClip dash;
    public AudioClip jump;
}
