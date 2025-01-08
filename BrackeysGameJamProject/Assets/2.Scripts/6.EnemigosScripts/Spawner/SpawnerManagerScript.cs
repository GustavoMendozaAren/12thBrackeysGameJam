using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManagerScript : MonoBehaviour
{
    [Header("SPAWNERS")]
    [SerializeField] private GameObject[] spawners;

    public void ActivateSpawner()
    {
        if(StaticVariables.diasTranscurridos == 1)
        {
            spawners[0].SetActive(true);
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
            spawners[0].SetActive(false);
        }
        //foreach (GameObject spawner in spawners)
        //{
        //    spawner.gameObject.SetActive(false);
        //}
    }
}
