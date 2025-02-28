using UnityEngine;

public class OptionsButtonController : MonoBehaviour
{
    public GameObject optionsMenu;

    void Start()
    {
        if (optionsMenu != null)
        {
            optionsMenu.SetActive(false);
        }
    }

    public void OnOptionsButtonClick()
    {
        if (optionsMenu != null)
        {
            optionsMenu.SetActive(!optionsMenu.activeSelf);
        }
    }

    public void OnOkButtonClick()
    {
        if (optionsMenu != null)
        {
            optionsMenu.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenu != null && optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(false);
            }
        }
    }
}