using UnityEngine;
using UnityEngine.UI;

public class FullScreenToggleController : MonoBehaviour
{
    public Image checkBoxImage;
    public Sprite checkedSprite;
    public Sprite uncheckedSprite;

    void Start()
    {
        UpdateCheckBoxSprite(Screen.fullScreen);
    }

    public void OnToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;

        UpdateCheckBoxSprite(Screen.fullScreen);
    }

    private void UpdateCheckBoxSprite(bool isFullScreen)
    {
        if (isFullScreen)
        {
            checkBoxImage.sprite = checkedSprite;
        }
        else
        {
            checkBoxImage.sprite = uncheckedSprite;
        }
    }
}