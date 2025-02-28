using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class VideoIntro : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public GameObject skipTextObject;
    private bool hasSeenIntro;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;

        hasSeenIntro = PlayerPrefs.GetInt("HasSeenIntro", 0) == 1;

        skipTextObject.SetActive(false);
    }

    void Update()
    {
        if (hasSeenIntro && Input.GetKeyDown(KeyCode.E)) //Con lo que me costo hacer la intro la vas a skipear? :(
        {
            StartCoroutine(ShowSkipText());
        }
    }

    IEnumerator ShowSkipText()                           //Para Que?
    {                                                    //No... lo... se...
        skipTextObject.SetActive(true);
        yield return new WaitForSeconds(1);              //Seguramente para hacer otro bug YEAH
        skipTextObject.SetActive(false);
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        PlayerPrefs.SetInt("HasSeenIntro", 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene("1-1");
    }
}