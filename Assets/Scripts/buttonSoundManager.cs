using UnityEngine;

public class ButtonSoundManager : MonoBehaviour
{
    public static AudioClip flipSound, btnClickSound;
    static AudioSource audioSource;
    void Start()
    {
        btnClickSound = Resources.Load<AudioClip>("Menu_Select2");
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlayBtnClickSound()
    {
        audioSource.PlayOneShot(btnClickSound);
    }
}
