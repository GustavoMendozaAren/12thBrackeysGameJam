using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionesDeVictoria : MonoBehaviour
{
    [Header("PANELES")]
    [SerializeField] private GameObject VictoryPanel;
    [SerializeField] private GameObject VictoryPanelBarrera;
    [SerializeField] private GameObject DefeatedPanel;
    [SerializeField] private GameObject DefeatedPanelBarrera;

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
        DefeatedPanelBarrera.SetActive(true);
        StartCoroutine(DefeatedBarreraAppear());
    }

    IEnumerator DefeatedBarreraAppear()
    {
        DefeatedPanel.SetActive(true);
        yield return new WaitForSeconds(4f);
        DefeatedPanelBarrera.SetActive(false);
        Time.timeScale = 0f;
    }
}
