using UnityEngine;
using TMPro;

public class PlayerNameDisplay : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextFadeController textFadeController;

    void Start()
    {
        playerNameText.text = PlayerPrefs.GetString("PlayerName House's", "Player 1 House's");

        if (textFadeController != null)
        {
            textFadeController.StartFadeSequence();
        }
        else
        {
            Debug.LogError("No TextFadeController assigned to PlayerNameDisplay.");
        }
    }
}