using UnityEngine;

public class SunMovement : MonoBehaviour //El movimiento del Sol es algo relativo
{
    public float fallSpeed = 2.0f; 
    public float groundY = -4.5f; 
    public GameObject targetObject; 
    public float clickSpeed = 8.0f;
    public AudioClip clickSound;
    public System.Action<int> AddScoreAction;

    private bool isClicked = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (!isClicked)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;

            if (transform.position.y <= groundY)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Vector3 targetPosition = targetObject.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, clickSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!isClicked)
        {
            isClicked = true;

            if (clickSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(clickSound);
            }

            AddScoreAction?.Invoke(25); //Porque tan poco?, no ven que hay INFLACIONNNNNNNNNNNN WAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        }
    }
}