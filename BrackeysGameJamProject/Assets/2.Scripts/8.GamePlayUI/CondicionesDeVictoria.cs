using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionesDeVictoria : MonoBehaviour
{
    [Header("PANELES")]
    [SerializeField] private GameObject VictoryPanel;
    [SerializeField] private GameObject DefeatedPanel;
    private MusicManager musicManager;

    private void Start()
    {
        VictoryPanel.SetActive(false);
        DefeatedPanel.SetActive(false);
        GameObject instanciaMusic = GameObject.Find("Music");
        musicManager = instanciaMusic.GetComponent<MusicManager>();
        musicManager.OnGameStateChanged(0);
    }

    public void Victoria()
    {
        VictoryPanel.SetActive(true);
        Time.timeScale = 0f;
        musicManager.OnGameStateChanged(1);
    }

    public void Derrota()
    {
        DefeatedPanel.SetActive(true);
        Time.timeScale = 0f;
        musicManager.OnGameStateChanged(2);
    }
}
