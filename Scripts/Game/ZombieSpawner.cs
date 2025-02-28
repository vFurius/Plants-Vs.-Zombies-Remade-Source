using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject regularZombiePrefab;
    public Transform[] spawnPoints;
    public int numberOfZombiesToSpawn = 5;

    void Start()
    {
        SpawnZombiesAtSpawnPoints();
    }

    void SpawnZombiesAtSpawnPoints()
    {
        numberOfZombiesToSpawn = Mathf.Clamp(numberOfZombiesToSpawn, 0, spawnPoints.Length);

        bool[] usedSpawnPoints = new bool[spawnPoints.Length];

        for (int i = 0; i < numberOfZombiesToSpawn; i++)
        {
            int randomIndex;

            do
            {
                randomIndex = Random.Range(0, spawnPoints.Length);
            } 
            while (usedSpawnPoints[randomIndex]);

            usedSpawnPoints[randomIndex] = true;

            Instantiate(regularZombiePrefab, spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);
        }
    }
}