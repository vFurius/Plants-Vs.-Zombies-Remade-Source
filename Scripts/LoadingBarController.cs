using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingBarController : MonoBehaviour
{
    public Image loadBarGrass;
    public Image sodRollCap;
    public TextMeshProUGUI loadingText;
    public float maxWidth;
    public float rollSpeed = 360f;

    private bool isClickable = false;

    void Start()
    {
        if (loadBarGrass == null || sodRollCap == null || loadingText == null)
        {
            Debug.LogError("Una o más referencias no están asignadas en el Inspector.");
            return;
        }

        loadBarGrass.fillAmount = 0;
        sodRollCap.gameObject.SetActive(true);
        sodRollCap.rectTransform.anchoredPosition = new Vector2(-maxWidth / 2, sodRollCap.rectTransform.anchoredPosition.y);

        loadingText.gameObject.SetActive(true);
        loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, 1f);

        StartCoroutine(AnimateLoadingBar());
    }

    IEnumerator AnimateLoadingBar()
    {
        float progress = 0f;
        while (progress < 1f)
        {
            progress += Time.deltaTime / 10;
            UpdateLoadingBar(progress);
            yield return null;
        }
        UpdateLoadingBar(1f);
        isClickable = true;
    }

    //Quisas funcione sin ningun tipo de bug... o no?...

    void UpdateLoadingBar(float progress)
    {
        loadBarGrass.fillAmount = progress;

        float newPosX = Mathf.Lerp(-maxWidth / 2, maxWidth / 2, progress);
        sodRollCap.rectTransform.anchoredPosition = new Vector2(newPosX, sodRollCap.rectTransform.anchoredPosition.y);

        sodRollCap.transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime);

        if (progress < 1f)
        {
            loadingText.text = "LOADING...";
        }
        else
        {
            loadingText.text = "CLICK HERE TO START!"; //HAY UN ERROR AL CLICKEAR EN LA PANTALLA ALEATOREAMENTE... ARREGLALO FURIUS
        }
    }

    void Update()
    {
        if (isClickable && Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("WarningNote"); //Leelo bien bro porfis
    }
}