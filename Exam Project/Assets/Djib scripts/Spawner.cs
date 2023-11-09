using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);


            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];


            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

