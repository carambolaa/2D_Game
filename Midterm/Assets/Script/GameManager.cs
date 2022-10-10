using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mushuroom;
    [SerializeField] GameObject skeleton;
    [SerializeField] GameObject flight;
    [SerializeField] GameObject player;

    int spawnCounter = 1;

    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        SpawnEnemies(flight, 5);
        yield return new WaitForSeconds(5f);
        SpawnEnemies(flight, 5);
        SpawnEnemies(skeleton, 5);
        yield return new WaitForSeconds(5f);
        SpawnEnemies(flight, 10);
        SpawnEnemies(skeleton, 5);
        SpawnEnemies(mushuroom, 5);
        yield return new WaitForSeconds(5f);

        while (true)
        {
            SpawnEnemies(flight, 10 * spawnCounter++);
            yield return new WaitForSeconds(10f);

        }
        
    }

    void SpawnEnemies(GameObject enemyPrefab, int numberOfEnemies, bool isTracking = true)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPosition = Random.insideUnitCircle.normalized * 8;
            spawnPosition += player.transform.position;

            GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

   
}
