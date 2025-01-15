using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManagerScript : MonoBehaviour
{
    [Header("SPAWNERS")]
    [SerializeField] private GameObject[] spawners; // 0-Basic, 1-Healer, 2-Tank

    public void ActivateSpawner()
    {
        if(StaticVariables.diasTranscurridos == 1)
        {
            Round1(true);
        }
        //foreach (GameObject spawner in spawners)
        //{
        //    spawner.gameObject.SetActive(true);
        //}
    }

    public void DeactivateSpawners()
    {
        if (StaticVariables.diasTranscurridos == 1)
        {
            Round1(false);
        }
        //foreach (GameObject spawner in spawners)
        //{
        //    spawner.gameObject.SetActive(false);
        //}
    }

    // HORDAS DE ENEMIGOS

    private void Round1(bool active)
    {
        spawners[0].SetActive(active);
    }
}
