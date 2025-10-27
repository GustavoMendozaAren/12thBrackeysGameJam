using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTest : MonoBehaviour
{
    [Header("EMEIGOS PREFAB")]
    [SerializeField] private GameObject enemyBasicPrefab;
    [SerializeField] private GameObject enemyHealerPrefab;
    [SerializeField] private GameObject enemyTankPrefab;


    [Header("Enemy Settings")]
    [SerializeField] private Transform[] waypoints;   // Puntos que seguirán los enemigos

    [Header("Spawn Settings")]
    [SerializeField] private Transform[] spawnPoints;    // Punto de spawn de los enemigos
    private int spawnDelay = 3; // Retraso entre cada spawn

    // Time Stuff
    private float timerToAppearBasic = 0f;
    private float timerToAppearHealer = 0f;
    private bool timerIsRunning = false;

    private int enemyCounter = 0;

    private void Update()
    {
        SpawnBasicenEmies(6);
        if (timerIsRunning)
        {
            HordasMetodo();
        }
        else
        {
            return;
        }
    }

    public void StartSpawningEnemies()
    {
        timerToAppearBasic = 0f;
        timerToAppearHealer = 0f;
        timerIsRunning = true;
        enemyCounter = 0;
    }

    void HordasMetodo()
    {
        if(StaticVariables.diasTranscurridos == 1)
        {
            SpawnBasicenEmies(5);
        }
        if (StaticVariables.diasTranscurridos == 2)
        {
            SpawnBasicenEmies(8);
        }
        if (StaticVariables.diasTranscurridos == 3)
        {
            SpawnBasicenEmies(8);
        }
    }

    void SpawnBasicenEmies(int enemyQuantity)
    {
        if (enemyCounter < enemyQuantity)
        {
            timerToAppearBasic += (Time.deltaTime / spawnDelay) * StaticVariables.enemiesSpeed;
            if (timerToAppearBasic >= 1f)
            {
                CreateEnemyBasic(spawnPoints[0]);
                timerToAppearBasic = 0f;
            }
        }
        else
        {
            timerIsRunning = false;
            return;
        }
    }

    void SpawnHealerEnemies(int enemyQuantity)
    {
        if (enemyCounter < enemyQuantity)
        {
            timerToAppearHealer += (Time.deltaTime / spawnDelay) * StaticVariables.enemiesSpeed;
            if (timerToAppearHealer >= 1.5f)
            {
                CreateEnemyHealer(spawnPoints[0]);
                timerToAppearHealer = 0f;
            }
        }
        else
        {
            timerIsRunning = false;
            return;
        }
    }

    void CreateEnemyBasic(Transform spawnPt)
    {
        GameObject enemyBasic = Instantiate(enemyBasicPrefab, spawnPt.position, Quaternion.identity);
        enemyBasic.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
        enemyCounter++;
    }

    void CreateEnemyHealer(Transform spawnPt)
    {
        GameObject enemyHealer = Instantiate(enemyHealerPrefab, spawnPt.position, Quaternion.identity);
        enemyHealer.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
        enemyCounter++;
    }

    void CreateEnemyTank(Transform spawnPt)
    {
        GameObject enemyTank = Instantiate(enemyTankPrefab, spawnPt.position, Quaternion.identity);
        enemyTank.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
        enemyCounter++;
    }

    //void TimerSpawner( int enemyQuantity)
    //{
    //    if (enemyCounter < enemyQuantity) 
    //    {
    //        timerToAppearBasic += (Time.deltaTime / spawnDelay) * StaticVariables.enemiesSpeed;
    //        if (timerToAppearBasic >= 1f)
    //        {
    //            //CreateEnemyBasic();
    //            timerToAppearBasic = 0f;
    //        }
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
}
