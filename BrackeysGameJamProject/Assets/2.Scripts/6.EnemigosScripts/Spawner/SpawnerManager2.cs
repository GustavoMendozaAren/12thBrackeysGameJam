using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager2 : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private GameObject enemyPrefab1;  // Prefab del enemigo
    [SerializeField] private GameObject enemyPrefab2;  // Prefab del enemigo
    [SerializeField] private GameObject enemyPrefab3;  // Prefab del enemigo
    [SerializeField] private Transform[] waypoints;   // Puntos que seguirán los enemigos
    //[SerializeField] private int enemyCount = 5;      // Cantidad de enemigos a instanciar

    [Header("Spawn Settings")]
    [SerializeField] private Transform[] spawnPoint;    // Punto de spawn de los enemigos
    [SerializeField] private int spawnDelay = 5; // Retraso entre cada spawn

    // Time Stuff
    private float timeRemaining = 180f;
    private bool timerIsRunning = false;
    private int smallCounter = 0;
    private int minutes;

    // New Time stuff
    private bool spawnNow = false;
    private float temporizador;
    [SerializeField] private float tiempoEntreSpawns = 2f;

    private int enemyCounter = 0;

    private void Start()
    {
        temporizador = tiempoEntreSpawns;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            StopWatchFunc();
            TemporizadorSpawn();
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

    void TemporizadorSpawn()
    {
        temporizador -= Time.deltaTime * StaticVariables.enemiesSpeed;

        if (temporizador <= 0f)
        {
            spawnNow = true;
            temporizador = tiempoEntreSpawns;
        }
        else
        {
            spawnNow = false;
        }
    }

    // Esto va en el boton de terminar noche
    public void SpawnEnemies()
    {
        timeRemaining = 180f;
        timerIsRunning = true;
        enemyCounter = 0;
        ActiveSpawnersMethod();
    }

    void ActiveSpawnersMethod()
    {
        if (StaticVariables.diasTranscurridos < 2)
        {
            // 7 enemigos basicos
            //FirstSpawnerActive();
            PruebaNumero1(7);
        }
        else if (StaticVariables.diasTranscurridos < 3)
        {
            // 7 basicos por ambos lados y 1 helaer
            FirstSpawnerActive();
            SecondSpawnerActive();
        }else if (StaticVariables.diasTranscurridos < 4)
        {
            // 7 basicos por todos lados, 2 healer y 1 tanque
            FirstSpawnerActive();
            SecondSpawnerActive();
        }

    }

    void PruebaNumero1(int cantidad)
    {
        if (spawnNow) 
        {
            int _cantidad = 0;

            if (_cantidad < cantidad)
            {
                GameObject enemy = Instantiate(enemyPrefab1, spawnPoint[0].position, Quaternion.identity);
                enemy.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
                enemyCounter++;
            }
        }
    }

    void FirstSpawnerActive()
    {
        if (spawnNow)
        {
            AppearBasicEnemies(7);
        }
    }

    void SecondSpawnerActive()
    {
        if (smallCounter == 1)
        {
            if (enemyCounter < (StaticVariables.diasTranscurridos * 2))
            {
                //AppearBasicEnemies();
            }
        }
    }

    void ThirdSpawnerActive()
    {
        if (smallCounter == 1)
        {
            if (enemyCounter < (StaticVariables.diasTranscurridos * 2))
            {
                //AppearBasicEnemies();
            }
        }
    }

    void AppearBasicEnemies(int cantidad)
    {
        int _cantidad = 0;

        if (_cantidad < cantidad)
        {
            GameObject enemy = Instantiate(enemyPrefab1, spawnPoint[0].position, Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
            enemyCounter++;
        }
    }

    void AppearMedicEnemies()
    {
        GameObject enemy = Instantiate(enemyPrefab2, spawnPoint[0].position, Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
        enemyCounter++;
    }

    void AppearTankEnemies()
    {
        GameObject enemy = Instantiate(enemyPrefab3, spawnPoint[0].position, Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
        enemyCounter++;
    }

    bool EsDivisibleEntreN(int num, int divisor)
    {
        return num % divisor == 0;
    }
}
