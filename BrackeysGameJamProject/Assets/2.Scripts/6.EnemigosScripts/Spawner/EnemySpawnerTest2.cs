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
    [SerializeField] private Transform[] waypoints;

    [Header("Spawn Settings")]
    [SerializeField] private Transform[] spawnPoints;

    // Seconds btween enemies
    private int spawnDelay = 3;

    // Start to spawn enemies
    private bool timerIsRunning = false;

    // Enemy Timers
    private float timerToAppearBasic = 0f;
    private float timerToAppearHealer = 0f;
    private float timerToAppearTank = 0f;
    
    // Enemy Counters
    private int basicEnemyCounter = 0;
    private int healerEnemyCounter = 0;
    private int tankEnemyCounter = 0;
    int counter = 0;

    private void Update()
    {
        SpawnBasicEnemies(3);
        SpawnHealerEnemies(1);
        //SpawnTankEnemies(1);

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
        timerToAppearHealer = 0f;
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
            
        }
    }

    void SpawnBasicEnemies(int enemigosDeseados)
    {
        if (basicEnemyCounter < enemigosDeseados)
        {
            timerToAppearBasic += (Time.deltaTime / 3) * StaticVariables.enemiesSpeed;

            if (timerToAppearBasic >= 1f)
            {
                InstanciarBasico(spawnPoints[0], new Vector3(0f, 0f, 0f));
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
            timerToAppearHealer += (Time.deltaTime / 6) * StaticVariables.enemiesSpeed;

            if (timerToAppearHealer >= 1f)
            {
                InstanciarCurador(spawnPoints[0], new Vector3 (0f, 0.55f, 0f));
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
            timerToAppearTank += (Time.deltaTime / 8) * StaticVariables.enemiesSpeed;

            if (timerToAppearTank >= 1f)
            {
                InstanciarTanque(spawnPoints[0], new Vector3(0f, .65f, 0f));
                timerToAppearTank = 0f;
            }
        }
        else
        {
            return;
        }
    }

    void SpawnTankAndOthers(int enemigosDeseados)
    {
        if (basicEnemyCounter < enemigosDeseados)
        {
            timerToAppearTank += (Time.deltaTime / spawnDelay) * StaticVariables.enemiesSpeed;
            timerToAppearHealer += (Time.deltaTime / spawnDelay) * StaticVariables.enemiesSpeed;
            timerToAppearBasic += (Time.deltaTime / spawnDelay) * StaticVariables.enemiesSpeed;

            if (timerToAppearTank >= 4f)
            {
                //InstanciarTanque(spawnPoints[0]);
                timerToAppearTank = 0f;
                timerToAppearHealer = 0f;
                timerToAppearBasic = 0f;
            }
            else if (timerToAppearHealer >= 2f)
            {
                //InstanciarCurador(spawnPoints[0]);
                timerToAppearHealer = 0f;
                timerToAppearBasic = 0f;
            }
            else if (timerToAppearBasic >= 1f)
            {
                //InstanciarBasico(spawnPoints[0]);
                timerToAppearBasic = 0f;
            }
        }
        else
        {
            timerIsRunning = false;
            return;
        }
    }
    void InstanciarBasico(Transform spawnPt, Vector3 offset)
    {
        GameObject enemyBasic = Instantiate(enemyBasicPrefab, spawnPt.position + offset, Quaternion.identity);
        enemyBasic.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
        basicEnemyCounter++;
    }

    void InstanciarCurador(Transform spawnPt, Vector3 offset)
    {
        GameObject enemyHealer = Instantiate(enemyHealerPrefab, spawnPt.position + offset , Quaternion.identity);
        enemyHealer.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
        healerEnemyCounter++;
    }

    void InstanciarTanque(Transform spawnPt, Vector3 offset)
    {
        GameObject enemyTank = Instantiate(enemyTankPrefab, spawnPt.position + offset, Quaternion.identity);
        enemyTank.GetComponent<EnemyMovement>().SetWaypoints(waypoints);
        tankEnemyCounter++;
    }
}
