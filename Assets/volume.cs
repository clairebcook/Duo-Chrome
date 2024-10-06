using UnityEngine;
using UnityEngine.UI;

public class volumeSlider : MonoBehaviour
{
    public Slider volumeSlide;

    void Start()
    {
        volumeSlide.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        AudioListener.volume = volumeSlide.volume;

        volumeSlide.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
