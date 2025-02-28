using UnityEngine;
using TMPro;

public class SunSpawner : MonoBehaviour
{
    public GameObject sunPrefab;
    public float spawnInterval = 5.0f;
    public float fallSpeed = 2.0f;
    public float minX = -7.5f;
    public float maxX = 7.5f;
    public float spawnHeight = 6.0f;
    public float groundY = -4.5f;
    public GameObject scoreTextObject;
    public float clickSpeed = 8.0f;
    public AudioClip clickSound;

    private int score = 50;
    private const int maxScore = 9999; // Pude haber puesto un limite mas grande, pero no quiero seguir bugeando el Bugs Vs. Bugs Remade...
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
            UpdateScoreText();
        }
        else
        {
            Debug.LogError("Score Text GameObject no asignado.");
        }

        InvokeRepeating("SpawnSun", 2.0f, spawnInterval);
    }

    private void SpawnSun()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), spawnHeight, 0);
        GameObject newSun = Instantiate(sunPrefab, spawnPosition, Quaternion.identity);

        SunMovement sunMovement = newSun.AddComponent<SunMovement>();
        sunMovement.fallSpeed = fallSpeed;
        sunMovement.groundY = groundY;
        sunMovement.targetObject = scoreTextObject;
        sunMovement.clickSpeed = clickSpeed;
        sunMovement.clickSound = clickSound;
        sunMovement.AddScoreAction = AddScore;
    }

    private void AddScore(int amount)
    {
        score = Mathf.Clamp(score + amount, 25, maxScore);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}