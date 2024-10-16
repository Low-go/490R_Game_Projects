using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float xRange = 44;
    private float zRange = 44;
    private float startDelay = 4;
    public GameObject enemyPrefab;
    public Transform player;  // players position
    private float safeDistance = 3.0f;
    private int enemiesPerWave = 8;  // Number of enemies to spawn at once

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            spawnEnemiesAtRandom();
            float spawnInterval = Random.Range(2, 5); // New random time for each spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void spawnEnemiesAtRandom()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            Vector3 spawnPos;
            do
            {
                spawnPos = new Vector3(Random.Range(-xRange, xRange), 0.5f, Random.Range(-zRange, zRange));
            } while (Vector3.Distance(spawnPos, player.position) < safeDistance);

            Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame, I might not need this
    void Update()
    {

    }
}
