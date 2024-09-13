using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private GameObject enemyPrefab;  // Prefab del enemigo
    [SerializeField] private Transform[] waypoints;   // Puntos que seguirán los enemigos
    [SerializeField] private int enemyCount = 5;      // Cantidad de enemigos a instanciar

    [Header("Spawn Settings")]
    [SerializeField] private Transform spawnPoint;    // Punto de spawn de los enemigos
    [SerializeField] private float spawnDelay = 0.5f; // Retraso entre cada spawn

    public void SpawnEnemies()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().SetWaypoints(waypoints);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
