using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTest2 : MonoBehaviour
{
    [Header("EMEIGOS PREFAB")]
    [SerializeField] private GameObject enemyBasicPrefab;
    [SerializeField] private GameObject enemyHealerPrefab;
    [SerializeField] private GameObject enemyTankPrefab;


    [Header("Enemy Settings")]
    [SerializeField] private Transform[] waypointsBasic;
    [SerializeField] private Transform[] waypointsHealer;
    [SerializeField] private Transform[] waypointsTank;

    [Header("Spawn Settings")]
    [SerializeField] private Transform[] spawnPointBasic;
    [SerializeField] private Transform[] spawnPointHealer;
    [SerializeField] private Transform[] spawnPointTank;

    // Seconds btween enemies
    private int spawnDelay = 3;

    // Start to spawn enemies
    private bool timerIsRunning = false;

    // Enemy Timers
    private float timerToAppearBasic = 0f;
    private float timerToAppearHealer = -0.5f;
    private float timerToAppearTank = 0f;
    
    // Enemy Counters
    private int basicEnemyCounter = 0;
    private int healerEnemyCounter = 0;
    private int tankEnemyCounter = 0;
    int counter = 0;

    private void Update()
    {
        HordasPorDia();

        if (!timerIsRunning)
        {
            return;
        }
        else
        {
            HordasPorDia();
        }
    }

    public void StartSpawningEnemiesBtn()
    {
        timerToAppearBasic = 0f;
        timerToAppearHealer = -0.5f;
        timerToAppearTank = 0f;

        basicEnemyCounter = 0;
        healerEnemyCounter = 0;
        tankEnemyCounter = 0;

        timerIsRunning = true;
    }

    void HordasPorDia()
    {
        if (StaticVariables.diasTranscurridos == 1)
        {
            SpawnBasicEnemies(5);
            SpawnHealerEnemies(2);
            //SpawnTankEnemies(1);
        }
    }

    void SpawnBasicEnemies(int enemigosDeseados)
    {
        if (basicEnemyCounter < enemigosDeseados)
        {
            timerToAppearBasic += (Time.deltaTime / 3) * StaticVariables.enemiesSpeed;

            if (timerToAppearBasic >= 1f)
            {
                InstanciarBasico(spawnPointBasic[0]);
                timerToAppearBasic = 0f;
            }
        }
        else
        {
            return;
        }
    }

    void SpawnHealerEnemies(int enemigosDeseados)
    {
        if (healerEnemyCounter < enemigosDeseados)
        {
            timerToAppearHealer += (Time.deltaTime / 3) * StaticVariables.enemiesSpeed;

            if (timerToAppearHealer >= 1f)
            {
                InstanciarCurador(spawnPointHealer[0]);
                timerToAppearHealer = 0f;
            }
        }
        else
        {
            return;
        }
    }

    void SpawnTankEnemies(int enemigosDeseados)
    {
        if (tankEnemyCounter < enemigosDeseados)
        {
            timerToAppearTank += (Time.deltaTime / 6) * StaticVariables.enemiesSpeed;

            if (timerToAppearTank >= 1f)
            {
                InstanciarTanque(spawnPointTank[0]);
                timerToAppearTank = 0f;
            }
        }
        else
        {
            return;
        }
    }
    void InstanciarBasico(Transform spawnPt)
    {
        GameObject enemyBasic = Instantiate(enemyBasicPrefab, spawnPt.position, Quaternion.identity);
        enemyBasic.GetComponent<EnemyMovement>().SetWaypoints(waypointsBasic);
        basicEnemyCounter++;
    }

    void InstanciarCurador(Transform spawnPt)
    {
        GameObject enemyHealer = Instantiate(enemyHealerPrefab, spawnPt.position, Quaternion.identity);
        enemyHealer.GetComponent<EnemyMovement>().SetWaypoints(waypointsHealer);
        healerEnemyCounter++;
    }

    void InstanciarTanque(Transform spawnPt)
    {
        GameObject enemyTank = Instantiate(enemyTankPrefab, spawnPt.position, Quaternion.identity);
        enemyTank.GetComponent<EnemyMovement>().SetWaypoints(waypointsTank);
        tankEnemyCounter++;
    }
}
