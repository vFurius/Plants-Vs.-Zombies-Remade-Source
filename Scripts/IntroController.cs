using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class IntroSequence : MonoBehaviour
{
    public Image popcapLogo;                //Aunque no hicieran nada aqui, si lo hicieron para motivarme hacer este proyecto...
    public Image infinitechLogo;              //Nose porque pongo una empresa si estoy yo solo :( || (Actualizacion 25/02/2025) CanineLotus es un kpo GRAX POR PRESTARME TU MUSICA
    public TextMeshProUGUI infinitechText;    //Sera que ¿Es parte del proyecto indirectamente y que no estoy solo?... Ni idea... Yo solo programo
    public float logoDisplayTime = 2.0f;      
    public float fadeDuration = 1.0f;
    public string nextSceneName;

    void Start()
    {
        popcapLogo.gameObject.SetActive(false);
        infinitechLogo.gameObject.SetActive(false);
        infinitechText.gameObject.SetActive(false);

        StartCoroutine(PlayIntroSequence());
    }

    IEnumerator PlayIntroSequence()
    {
        yield return StartCoroutine(FadeIn(popcapLogo));
        yield return new WaitForSeconds(logoDisplayTime);
        yield return StartCoroutine(FadeOut(popcapLogo));

        yield return StartCoroutine(FadeIn(infinitechLogo));
        yield return StartCoroutine(FadeInText(infinitechText));
        yield return new WaitForSeconds(logoDisplayTime);
        yield return StartCoroutine(FadeOut(infinitechLogo));
        yield return StartCoroutine(FadeOutText(infinitechText));

        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator FadeIn(Image image)
    {
        image.gameObject.SetActive(true);
        Color color = image.color;
        float startAlpha = 0f;
        float endAlpha = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            color.a = alpha;
            image.color = color;
            yield return null;
        }

        color.a = endAlpha;
        image.color = color;
    }

    IEnumerator FadeOut(Image image)
    {
        Color color = image.color;
        float startAlpha = 1f;
        float endAlpha = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            color.a = alpha;
            image.color = color;
            yield return null;
        }

        color.a = endAlpha;
        image.color = color;
        image.gameObject.SetActive(false);
    }

    IEnumerator FadeInText(TextMeshProUGUI text)
    {
        text.gameObject.SetActive(true);
        Color color = text.color;
        float startAlpha = 0f;
        float endAlpha = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            color.a = alpha;
            text.color = color;
            yield return null;
        }

        color.a = endAlpha;
        text.color = color;
    }

    IEnumerator FadeOutText(TextMeshProUGUI text)  //Cuantos problemas me generaste TextMeshPro... Y GRACIAS POR FACILITARME TODO EL TRABAJO
    {
        Color color = text.color;
        float startAlpha = 1f;
        float endAlpha = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            color.a = alpha;
            text.color = color;
            yield return null;
        }

        color.a = endAlpha;
        text.color = color;
        text.gameObject.SetActive(false);
    }
}