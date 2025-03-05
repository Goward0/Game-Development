using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    public int zombiesPerWave = 5;
    public float timeBetweenWaves = 10f;

    private int waveNumber = 1;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            SpawnZombies();
        }
    }

    void SpawnZombies()
    {
        for (int i = 0; i < zombiesPerWave; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
        }

        waveNumber++;
        zombiesPerWave += 2;
    }
}