using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControladorLoading : MonoBehaviour
{
    public TextMeshProUGUI loadingText;

    public void LoadNextScene(string sceneName)
    {
        if (loadingText != null && loadingText.text == "Click here to start!")
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("No se puede cambiar de escena aún. El texto actual es: " + (loadingText != null ? loadingText.text : "loadingText es nulo"));
        }
    }
}
