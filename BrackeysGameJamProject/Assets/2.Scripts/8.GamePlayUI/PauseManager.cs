using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private MusicManager musicManager;

    [Header("TUTORIAL PANELS")]
    [SerializeField] private GameObject[] tutPanel;

    [Header("PANELES")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pausePanelBarrera;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject controlsPanel;


    private void Start()
    {
        Time.timeScale = 0f;

        GameObject instanciaMusic = GameObject.Find("Music");
        musicManager = instanciaMusic.GetComponent<MusicManager>();
        musicManager.DayMusic(true);
    }
    public void PauseBttn()
    {
        pausePanel.SetActive(true);
        musicManager.IsPaused(true);
        StartCoroutine(PausePanelTime());
    }

    public void PauseBttnBack()
    {
        pausePanel.SetActive(false);
        musicManager.IsPaused(false);
        Time.timeScale = 1f;
    }

    public void ResetBttn()
    {
        SceneManager.LoadScene("TestTorretas");
        Time.timeScale = 1f;
        ResetVariables();
    }

    public void MainMenuBttn()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1f;
        ResetVariables();
    }

    public void OptionsBttn()
    {
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }

    public void ControlesBttn()
    {
        controlsPanel.SetActive(!controlsPanel.activeSelf);
    }

    private void ResetVariables()
    {
        StaticVariables.diasTranscurridos = 1;
        StaticVariables.cantidadAldeanosTotales = 0;
        StaticVariables.cantidadAldeanosDisponibles = 0;
        StaticVariables.cantidadBuildersTotales = 0;
        StaticVariables.cantidadBuildersDisponibles = 0;
    }

    IEnumerator PausePanelTime()
    {
        pausePanelBarrera.SetActive(true);
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(.9f);
        pausePanelBarrera.SetActive(false);
        Time.timeScale = 0f;
    }

    // TUTORIAL STUFF

    public void ContinueTut0Bttn()
    {
        tutPanel[0].SetActive(false);
        tutPanel[1].SetActive(true);
    }

    public void BackTutTo0Bttn()
    {
        tutPanel[0].SetActive(true);
        tutPanel[1].SetActive(false);
    }

    public void ContinueTut1Bttn()
    {
        tutPanel[1].SetActive(false);
        tutPanel[2].SetActive(true);
    }

    public void BackTutTo1Bttn()
    {
        tutPanel[1].SetActive(true);
        tutPanel[2].SetActive(false);
    }

    public void ContinueTut2Bttn()
    {
        tutPanel[2].SetActive(false);
        tutPanel[3].SetActive(true);
    }
    public void BackTutTo2Bttn()
    {
        tutPanel[2].SetActive(true);
        tutPanel[3].SetActive(false);
    }

    public void ContinueTut3Bttn()
    {
        tutPanel[3].SetActive(false);
        Time.timeScale = 1f;
    }
}
