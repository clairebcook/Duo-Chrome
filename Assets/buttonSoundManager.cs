using UnityEngine;

public class buttonSoundManager : MonoBehaviour
{
    public static AudioClip flipSound, btnClickSound;
    static AudioSource audioSource;
    void Start()
    {
        //flipSound = Resources.Load<AudioClip>("flipSound");
        btnClickSound = Resources.Load<AudioClip>("Menu_Select2");
        audioSource = GetComponent<AudioSource>();
    }
    /*public static void playFlipSound()
    {
        audioSource.PlayOneShot(flipSound);
    }*/
    public static void PlayBtnClickSound()
    {
        audioSource.PlayOneShot(btnClickSound);
    }
}
