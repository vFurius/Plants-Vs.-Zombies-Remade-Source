using UnityEngine;

// GRACIAS A DIOS QUE CREE ESTE SCRIPT, no es mucho pero como sirve.

public class MenuController : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject quitMenu;

    void Start()
    {
        if (optionsMenu != null)
        {
            optionsMenu.SetActive(false);
        }

        if (quitMenu != null)
        {
            quitMenu.SetActive(false);
        }
    }

    public void OnOptionsButtonClick()
    {
        if (quitMenu != null && quitMenu.activeSelf)
        {
            quitMenu.SetActive(false);
        }

        if (optionsMenu != null)
        {
            optionsMenu.SetActive(true);
        }
    }

    public void OnQuitButtonClick()
    {
        if (optionsMenu != null && optionsMenu.activeSelf)
        {
            optionsMenu.SetActive(false);
        }

        if (quitMenu != null)
        {
            quitMenu.SetActive(true);
        }
    }

    public void OnOkButtonClick()
    {
        if (optionsMenu != null)
        {
            optionsMenu.SetActive(false);
        }

        if (quitMenu != null)
        {
            quitMenu.SetActive(false);
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

            if (quitMenu != null && quitMenu.activeSelf)
            {
                quitMenu.SetActive(false);
            }
        }
    }
}