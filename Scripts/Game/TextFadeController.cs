using UnityEngine;
using TMPro;
using System.Collections;

public class TextFadeController : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    public float visibleDuration = 3.0f;

    private TextMeshProUGUI textMeshPro;
    private Color originalColor;

    void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        if (textMeshPro != null)
        {
            originalColor = textMeshPro.color;
        }
        else
        {
            Debug.LogError("No TextMeshProUGUI component found on this GameObject.");
        }
    }

    public void StartFadeSequence()
    {
        StartCoroutine(FadeInAndOut());
    }

    private IEnumerator FadeInAndOut()
    {
        yield return StartCoroutine(FadeText(0f, originalColor.a));

        yield return new WaitForSeconds(visibleDuration);

        yield return StartCoroutine(FadeText(originalColor.a, 0f));
    }

    private IEnumerator FadeText(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        Color color = textMeshPro.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            textMeshPro.color = color;
            yield return null;
        }

        color.a = endAlpha;
        textMeshPro.color = color;
    }
}