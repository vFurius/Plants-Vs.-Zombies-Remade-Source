using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public Vector3 targetPosition; 
    public float moveSpeed = 2.0f;  
    public float delayBeforeMoving = 2.0f;
    public Vector3 originalPosition = new Vector3(-1.38f, 0f, -15.5f);
    public GameObject preparadosImage;
    public GameObject listoImage;
    public GameObject plantaImage;
    public AudioSource audioSource;
    public AudioClip introMusic; // Música antes del "Preparados, Listo, ¡Planta!"
    public AudioClip generalClip; // Sonido del "Preparados, Listo, ¡Planta!"
    public AudioClip gameplayMusic; // Música después del "¡Planta!"
    public GameObject podadora;
    public GameObject seedbank;
    public GameObject sunSpawner;
    public GameObject[] staticTextElements;

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is not assigned.");
        }

        if (introMusic != null && audioSource != null)
        {
            audioSource.clip = introMusic;
            audioSource.Play(); // Reproduce la música inicial al iniciar
        }

        if (preparadosImage != null) preparadosImage.SetActive(false);
        if (listoImage != null) listoImage.SetActive(false);
        if (plantaImage != null) plantaImage.SetActive(false);
        if (podadora != null) podadora.SetActive(false);
        if (seedbank != null) seedbank.SetActive(false);
        if (sunSpawner != null) sunSpawner.SetActive(false);

        foreach (var textElement in staticTextElements)
        {
            if (textElement != null)
            {
                textElement.SetActive(false);
            }
        }

        StartCoroutine(MoveCamera());
    }

    IEnumerator MoveCamera()
    {
        yield return new WaitForSeconds(delayBeforeMoving);
        
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        
        transform.position = targetPosition;

        if (IsLevelInRange(SceneManager.GetActiveScene().name))
        {
            yield return new WaitForSeconds(3.0f);
            yield return StartCoroutine(ReturnToOriginalPosition());
        }
    }

    IEnumerator ShowImagesWithDelay()
    {
        if (podadora != null) 
        {
            podadora.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }

        if (preparadosImage != null) 
        {
            preparadosImage.SetActive(true);

            if (audioSource != null && generalClip != null)
            {
                audioSource.PlayOneShot(generalClip);
            }
            
            yield return new WaitForSeconds(0.5f);
            preparadosImage.SetActive(false);
        }

        if (listoImage != null) 
        {
            listoImage.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            listoImage.SetActive(false);
        }

        if (plantaImage != null) 
        {
            plantaImage.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            plantaImage.SetActive(false);
        }

        // Cambiar de la música de introducción a la música de gameplay
        if (audioSource != null)
        {
            audioSource.Stop(); // Detiene la música inicial
            if (gameplayMusic != null)
            {
                audioSource.clip = gameplayMusic;
                audioSource.Play(); // Reproduce la música del gameplay
            }
        }

        if (seedbank != null) seedbank.SetActive(true);
        if (sunSpawner != null) sunSpawner.SetActive(true);
        
        foreach (var textElement in staticTextElements)
        {
            if (textElement != null)
            {
                textElement.SetActive(true);
            }
        }
    }

    IEnumerator ReturnToOriginalPosition()
    {
        while (Vector3.Distance(transform.position, originalPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        
        transform.position = originalPosition;

        yield return new WaitForSeconds(1.0f);
        yield return StartCoroutine(ShowImagesWithDelay());
    }

    bool IsLevelInRange(string sceneName)
    {
        string[] allowedScenes = {"1-1", "1-2", "1-3", "1-4", "1-5", "1-6"};
        foreach (string level in allowedScenes)
        {
            if (sceneName.Equals(level))
            {
                return true;
            }
        }
        return false;
    }
}