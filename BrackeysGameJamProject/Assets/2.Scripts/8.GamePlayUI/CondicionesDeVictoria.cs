using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionesDeVictoria : MonoBehaviour
{
    [Header("PANELES")]
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject victoryPanelBarrera;
    [SerializeField] private GameObject defeatedPanel;
    [SerializeField] private GameObject defeatedPanelBarrera;
    private MusicManager musicManager;

    private void Start()
    {
        victoryPanel.SetActive(false);
        defeatedPanel.SetActive(false);
        GameObject instanciaMusic = GameObject.Find("Music");
        musicManager = instanciaMusic.GetComponent<MusicManager>();
        musicManager.OnGameStateChanged(0);
    }

    public void Victoria()
    {
        victoryPanel.SetActive(true);
        StartCoroutine(VBarrerasTiempo());
        musicManager.OnGameStateChanged(1);
    }

    public void Derrota()
    {
        defeatedPanel.SetActive(true);
        StartCoroutine(DBarrerasTiempo());
        musicManager.OnGameStateChanged(2);
    }

    IEnumerator DBarrerasTiempo()
    {
        defeatedPanelBarrera.SetActive(true);
        yield return new WaitForSeconds(6f);
        defeatedPanelBarrera.SetActive(false);
        Time.timeScale = 0f;
    }

    IEnumerator VBarrerasTiempo()
    {
        victoryPanelBarrera.SetActive(true);
        yield return new WaitForSeconds(5.5f);
        victoryPanelBarrera.SetActive(false);
        Time.timeScale = 0f;
    }
}
