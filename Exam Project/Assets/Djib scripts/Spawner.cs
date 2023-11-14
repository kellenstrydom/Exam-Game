using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject meleeEnemyPrefab;
    public GameObject shootingEnemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 4f;
    public float spawnDuration = 15f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        float elapsedTime = 0f;

        while (elapsedTime < spawnDuration)
        {
            yield return new WaitForSeconds(spawnInterval);

            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // 1 out of 3 chance to spawn shooting enemy, 2 out of 3 chance to spawn melee enemy
            if (Random.Range(0, 3) == 0)
            {
                Instantiate(shootingEnemyPrefab, spawnPoint.position, Quaternion.identity);
            }
            else
            {
                Instantiate(meleeEnemyPrefab, spawnPoint.position, Quaternion.identity);
            }

            elapsedTime += spawnInterval;
        }
    }
}

