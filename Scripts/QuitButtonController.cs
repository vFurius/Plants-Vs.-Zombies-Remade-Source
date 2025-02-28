using UnityEngine;

public class QuitButtonController : MonoBehaviour 
{
    public GameObject quitMenu;                                                                //De verdad gracias por hacer este script Furius... Me hubiese quedado atrapado para siempre en el juego

    void Start()
    {
        if (quitMenu != null)
        {
            quitMenu.SetActive(false);
        }
    }

    public void OnQuitButtonClick()
    {
        if (quitMenu != null)
        {
            quitMenu.SetActive(!quitMenu.activeSelf);
        }
    }

    public void OnCancelButtonClick()
    {
        if (quitMenu != null)
        {
            quitMenu.SetActive(false);
        }
    }

    public void OnConfirmQuitButtonClick()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (quitMenu != null && quitMenu.activeSelf)
            {
                quitMenu.SetActive(false);
            }
        }
    }
}