using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private GameObject enemyPrefab;  // Prefab del enemigo
    [SerializeField] private Transform[] waypoints;   // Puntos que seguirán los enemigos
    [SerializeField] private int enemyCount = 5;      // Cantidad de enemigos a instanciar

    [Header("Spawn Settings")]
    [SerializeField] private Transform spawnPoint;    // Punto de spawn de los enemigos
    [SerializeField] private int spawnDelay = 1; // Retraso entre cada spawn

    // Time Stuff
    private float timeRemaining = 180f;
    private bool timerIsRunning = false;
    private int smallCounter = 0;
    private int minutes;

    private int enemyCounter = 0;

    private void Update()
    {
        if (timerIsRunning)
        {
            StopWatchFunc();
            ApeearEnemyFunc();
        }
    }

    void StopWatchFunc()
    {
        minutes = (int)timeRemaining;
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime * StaticVariables.enemiesSpeed;
            if (EsDivisibleEntreCinco(minutes))
            {
                smallCounter++;
            }
            else
            {
                smallCounter = 0;
            }
        }
        else
        {
            timeRemaining = 0;
            timerIsRunning = false;
        }
    }

    public void SpawnEnemies()
    {
        timeRemaining = 180f;
        timerIsRunning = true;
        enemyCounter = 0;
    }

    void ApeearEnemyFunc()
    {
        if (smallCounter == 1)
        {
            if (enemyCounter < (4 + (StaticVariables.diasTranscurridos * 2)))
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
                enemyCounter++;
            }
        }
    }

    bool EsDivisibleEntreCinco(int num)
    {
        return num % 5 == 0;
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
