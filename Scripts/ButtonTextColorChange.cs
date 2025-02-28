using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonTextColorChange : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI buttonText;

    void Start()
    {
        if (button == null)
        {
            Debug.LogError("El botón no está asignado en el script ButtonTextColorChange.");
        }

        if (buttonText == null)
        {
            Debug.LogError("El texto del botón no está asignado en el script ButtonTextColorChange.");
        }

        if (button != null)
        {
            button.onClick.AddListener(ChangeTextColor);
        }
    }

    void ChangeTextColor()
    {
        if (buttonText != null)
        {
            buttonText.color = Color.green;
        }
    }
}