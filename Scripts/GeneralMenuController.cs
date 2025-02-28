using UnityEngine;
using UnityEngine.UI;

public class GeneralMenuController : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] menus;

    public void DisableAllButtons()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }

    public void EnableAllButtons()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }

    public void ShowMenu(GameObject menu)
    {
        DisableAllButtons();
        menu.SetActive(true);
    }

    public void CloseMenu(GameObject menu)
    {
        menu.SetActive(false);
        EnableAllButtons();
    }
}