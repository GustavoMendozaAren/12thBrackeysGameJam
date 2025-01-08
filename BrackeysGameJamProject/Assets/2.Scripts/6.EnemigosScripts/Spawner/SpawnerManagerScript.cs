using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManagerScript : MonoBehaviour
{
    [Header("SPAWNERS")]
    [SerializeField] private GameObject[] spawners;

    public void ActivateSpawner()
    {
        foreach (GameObject spawner in spawners)
        {
            spawner.gameObject.SetActive(true);
        }
    }

    public void DeactivateSpawners()
    {
        foreach (GameObject spawner in spawners)
        {
            spawner.gameObject.SetActive(false);
        }
    }
}
