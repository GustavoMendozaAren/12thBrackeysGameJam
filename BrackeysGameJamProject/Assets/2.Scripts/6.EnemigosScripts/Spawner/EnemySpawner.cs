using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private GameObject enemyPrefab;  // Prefab del enemigo
    [SerializeField] private Transform[] waypoints;   // Puntos que seguir�n los enemigos
    [SerializeField] private int enemyCount = 5;      // Cantidad de enemigos a instanciar

    [Header("Spawn Settings")]
    [SerializeField] private Transform spawnPoint;    // Punto de spawn de los enemigos
    [SerializeField] private int spawnDelay = 5; // Retraso entre cada spawn

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
            if (EsDivisibleEntreN(minutes, spawnDelay))
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
            timerIsRunning = false;
            timeRemaining = 0;
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
            if (enemyCounter < (enemyCount + (StaticVariables.diasTranscurridos * 2)))
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
                enemyCounter++;
            }
        }
    }

    bool EsDivisibleEntreN(int num, int divisor)
    {
        return num % divisor == 0;
    }

}
