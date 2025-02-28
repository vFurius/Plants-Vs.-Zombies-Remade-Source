using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsController : MonoBehaviour
{
    public Slider musicSlider;

    private AudioSource musicAudioSource;

    void Start()
    {
        MusicController musicController = FindObjectOfType<MusicController>();
        if (musicController != null)
        {
            musicAudioSource = musicController.GetComponent<AudioSource>();
        }

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        UpdateMusicVolume();
    }

    public void OnMusicVolumeChange()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        UpdateMusicVolume();
    }

    private void UpdateMusicVolume()
    {
        if (musicAudioSource != null)
        {
            musicAudioSource.volume = musicSlider.value;
        }
    }
}