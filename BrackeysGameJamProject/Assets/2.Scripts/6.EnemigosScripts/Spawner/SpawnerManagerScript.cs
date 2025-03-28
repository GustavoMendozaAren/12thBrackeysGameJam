using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerManagerScript : MonoBehaviour
{
    [SerializeField] private int[] basicoEnCadaHorda;
    [SerializeField] private int[] healerEnCadaHorda;
    [SerializeField] private int[] tankEnCadaHorda;

    [Header("SPAWNERS")]
    [SerializeField] private GameObject[] spawners; // 0-Basic, 1-Healer, 2-Tank
    MusicManager musicManager;

    private int cantidadDeHordas;
    private void Awake()
    {
        GameObject instanciaMusic = GameObject.Find("Music");
        musicManager = instanciaMusic.GetComponent<MusicManager>();
        musicManager.DayMusic(true);
    }

    private void Start()
    {
        cantidadDeHordas = ObtenerMayorLongitud(basicoEnCadaHorda, healerEnCadaHorda, tankEnCadaHorda);
    }
    public void ActivateSpawner()
    {
        ChecarSiHayDistintosEnemigos();
        
        //if (StaticVariables.diasTranscurridos == 1)
        //{
        //    Round1(true);
        //   musicManager.DayMusic(false);
        //}
        //foreach (GameObject spawner in spawners)
        //{
        //    spawner.gameObject.SetActive(true);
        //}
    }

    public void DeactivateSpawners()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].SetActive(false);
        }

        //if (StaticVariables.diasTranscurridos == 1)
        //{
        //    Round1(false);
        //    musicManager.DayMusic(true);
        //}
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

    private int ObtenerMayorLongitud(int[] array1, int[] array2, int[] array3)
    {
        // Comparar las longitudes de los tres arreglos
        return Math.Max(array1.Length, Math.Max(array2.Length, array3.Length));
    }

    private void ChecarSiHayDistintosEnemigos()
    {
        if (basicoEnCadaHorda.Length == 0)
            spawners[0].SetActive(false);
        else
            spawners[0].SetActive(true);

        if (healerEnCadaHorda.Length == 0)
            spawners[1].SetActive(false);
        else
            spawners[1].SetActive(true);

        if (tankEnCadaHorda.Length == 0)
            spawners[2].SetActive(false);
        else
            spawners[2].SetActive(true);
    }
}
