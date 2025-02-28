using UnityEngine;
using TMPro;

public class AdventureButtonController : MonoBehaviour
{
    public TextMeshProUGUI adventureText;
    private int currentLevel = 1;
    private int currentSubLevel = 1;

    void Start()
    {
        UpdateAdventureText();
    }

    public void OnAdventureButtonClick()
    {
        currentSubLevel++;

        if (currentSubLevel > 9)
        {
            currentSubLevel = 1;
            currentLevel++;

            if (currentLevel > 4)
            {
                currentLevel = 1;
            }
        }

        UpdateAdventureText();
    }

    private void UpdateAdventureText()
    {
        adventureText.text = "Level " + currentLevel + " - " + currentSubLevel;
    }
}