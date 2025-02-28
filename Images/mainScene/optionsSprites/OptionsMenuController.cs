using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle fullscreenToggle;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1.0f);
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void OnVolumeChange()
    {
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }

    public void OnFullscreenToggle()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
    }
}