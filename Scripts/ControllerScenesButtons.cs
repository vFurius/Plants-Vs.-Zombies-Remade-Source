using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerScenesButtons : MonoBehaviour
{
    public AudioClip buttonClickSound;
    public string sceneName;
    public AudioClip nextSceneMusic;
    public UnityEngine.Events.UnityEvent onClickAction;
    private AudioSource audioSource;
    private MusicController musicController;
    public bool stopMusicOnSceneChange = false;

    void Start()
    {
        Button button = GetComponent<Button>();
        audioSource = gameObject.AddComponent<AudioSource>();

        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("No se encontró un componente Button en el GameObject.");
        }

        if (buttonClickSound == null)
        {
            Debug.LogError("No se ha asignado un sonido para el clic del botón.");
        }

        musicController = FindObjectOfType<MusicController>();
    }

    void OnButtonClick()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
        else
        {
            Debug.LogError("No se pudo reproducir el sonido. audioSource o buttonClickSound es nulo.");
        }

        if (stopMusicOnSceneChange && musicController != null)
        {
            musicController.StopMusic();
        }

        if (nextSceneMusic != null && musicController != null)
        {
            musicController.SetNextSceneMusic(nextSceneMusic);
        }

        if (onClickAction != null)
        {
            Invoke("ExecuteOnClickAction", buttonClickSound.length);
        }

        if (!string.IsNullOrEmpty(sceneName))
        {
            Invoke("LoadScene", buttonClickSound != null ? buttonClickSound.length : 0);
        }
    }

    void ExecuteOnClickAction()
    {
        onClickAction.Invoke();
    }

    void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}