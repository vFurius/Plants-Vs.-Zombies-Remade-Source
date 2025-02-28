using UnityEngine;

public class AdventureButtonController1 : MonoBehaviour
{
    public Animator groundAnimator;
    public Animator handAnimator;
    public GameObject zombieHandObject;

    void Start()
    {
        if (zombieHandObject != null)
        {
            zombieHandObject.SetActive(false);
        }
    }

    public void OnAdventureButtonClick()
    {
        if (zombieHandObject != null)
        {
            zombieHandObject.SetActive(true);
        }

        if (groundAnimator != null)
        {
            groundAnimator.Play("groundHand");
        }

        if (handAnimator != null && zombieHandObject.activeSelf)
        {
            handAnimator.Play("ZombieHand_Emerge");
        }
    }
}