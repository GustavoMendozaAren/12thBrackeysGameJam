using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager2 : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private GameObject enemyPrefab1;  // Prefab del enemigo
    [SerializeField] private GameObject enemyPrefab2;  // Prefab del enemigo
    [SerializeField] private GameObject enemyPrefab3;  // Prefab del enemigo
    [SerializeField] private Transform[] waypointsS1;   // Puntos que seguirán los enemigos
    [SerializeField] private Transform[] waypointsS2;   // Puntos que seguirán los enemigos
    [SerializeField] private Transform[] waypointsS3;   // Puntos que seguirán los enemigos

    [Header("BasicEnemies")]
    [SerializeField] private int[] enemigosBasicosPorHorda;
    private int enemigosBasicosIndex;
    private int enemyBasicCounter = 0;

    [Header("HealerEnemies")]
    [SerializeField] private int[] enemigosHealerPorHorda;
    private int enemigosHealerIndex;
    private int enemyHealerCounter = 0;

    [Header("Spawn Settings")]
    [SerializeField] private Transform[] spawnPoint;    // Punto de spawn de los enemigos

    // Time Stuff
    private float timeRemaining = 180f;
    private bool timerIsRunning = false;

    // New Time stuff
    private float temporizador;
    [SerializeField] private float tiempoEntreSpawns = 2f;

    private void Start()
    {
        enemigosBasicosIndex = -1;
        enemigosHealerIndex = -1;
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
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime * StaticVariables.enemiesSpeed;
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
            temporizador = tiempoEntreSpawns;
            EnemigoBasicoSpawn();
        }
    }

    // Esto va en el boton de terminar noche
    public void SpawnEnemies()
    {
        enemigosBasicosIndex++;
        timeRemaining = 180f;
        timerIsRunning = true;
        enemyBasicCounter = 0;
    }

    void EnemigoBasicoSpawn()
    {
        if (enemyBasicCounter < enemigosBasicosPorHorda[enemigosBasicosIndex])
        {
            if (StaticVariables.diasTranscurridos < 2) 
            {
                BasicEnemigo(0, waypointsS1, Quaternion.identity);
            }
            else if (StaticVariables.diasTranscurridos < 3)
            {
                BasicEnemigo(0, waypointsS1, Quaternion.identity);
                BasicEnemigo(1, waypointsS2, Quaternion.AngleAxis(180f, Vector3.up));
            }
        }
    }

    void EnemigoHealerSpawn()
    {
        if (enemyHealerCounter < enemigosHealerPorHorda[enemigosHealerIndex])
        {
            if (StaticVariables.diasTranscurridos < 2)
            {
                HealerEnemigo(0, waypointsS1, Quaternion.identity);
            }
        }
    }

    void BasicEnemigo(int index, Transform[] waypoints, Quaternion angle)
    {
        GameObject enemy = Instantiate(enemyPrefab1, spawnPoint[index].position, angle);
        enemy.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
        enemyBasicCounter++;
    }

    void HealerEnemigo(int index, Transform[] waypoints, Quaternion angle)
    {
        GameObject enemy = Instantiate(enemyPrefab2, spawnPoint[index].position, angle);
        enemy.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
        enemyBasicCounter++;
    }

    void TankEnemigo(int index, Transform[] waypoints, Quaternion angle)
    {
        GameObject enemy = Instantiate(enemyPrefab3, spawnPoint[index].position, angle);
        enemy.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
        enemyBasicCounter++;
    }
}
