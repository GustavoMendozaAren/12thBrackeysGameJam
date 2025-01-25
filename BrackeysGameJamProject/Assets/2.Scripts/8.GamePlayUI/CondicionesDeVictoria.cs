using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionesDeVictoria : MonoBehaviour
{
    [Header("PANELES")]
    [SerializeField] private GameObject VictoryPanel;
    [SerializeField] private GameObject DefeatedPanel;

    private void Start()
    {
        VictoryPanel.SetActive(false);
        DefeatedPanel.SetActive(false);
    }

    public void Victoria()
    {
        VictoryPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Derrota()
    {
        DefeatedPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
