using UnityEngine;

public class ZombieHandController : MonoBehaviour
{
    public Animator animator;
    public AudioClip laughSound;
    public AudioSource audioSource;
    public float delayBeforeAnimation = 0.5f;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowZombieHand()
    {
        gameObject.SetActive(true);

        Invoke("PlayAnimation", delayBeforeAnimation);
    }

    private void PlayAnimation()
    {
        animator.SetTrigger("Emerge");

        if (audioSource != null && laughSound != null)
        {
            audioSource.PlayOneShot(laughSound);
        }
    }
}