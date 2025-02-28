using UnityEngine;

public class MusicController : MonoBehaviour  //El paraiso para Canine Lotus quizas deberia decirle que estoy poniendo mencionandolo cada 2 scripts... NAAA. GRAX BRO
{
    public AudioClip musicClip;
    private AudioSource audioSource;
    private static MusicController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (musicClip != null)
        {
            audioSource.clip = musicClip;
            audioSource.loop = true;
            audioSource.Play();

            float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
            audioSource.volume = savedVolume;
        }
        else
        {
            Debug.LogWarning("MusicClip no asignado en el Inspector.");
        }
    }

    public void StopMusic() //DAAAAAAAAAA QUE NO PARE LA MUSIC E E E E
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void ResumeMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void SetNextSceneMusic(AudioClip newMusic)
    {
        if (audioSource != null)
        {
            audioSource.clip = newMusic;
            audioSource.loop = true; // ES NECESARIO MANTENER EL LOOP Bro... es la gracia de la musica del juego...
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource no está configurado o es nulo.");
        }
    }
}