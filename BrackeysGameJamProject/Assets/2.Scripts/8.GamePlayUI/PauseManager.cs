using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private MusicManager musicManager;

    [Header("TUTORIAL PANELS")]
    [SerializeField] private GameObject[] tutPanel;
    [SerializeField] private GameObject closeTutBtn;

    [Header("PANELES")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pausePanelBarrera;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject controlsPanel;


    private void Start()
    {
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

    public void CloseTutBtnMethod()
    {
        closeTutBtn.SetActive(false);
    }

    public void TutQuitPanelBttn()
    {
        tutPanel[0].SetActive(false);
    }

    public void TutOpenPanelBttn()
    {
        tutPanel[0].SetActive(true);
    }

    public void TutControlsBtn()
    {
        tutPanel[1].SetActive(true);
        tutPanel[2].SetActive(false);
        tutPanel[3].SetActive(false);
        tutPanel[4].SetActive(false);
        tutPanel[5].SetActive(true);
        tutPanel[6].SetActive(true);
    }

    public void TutTimeBtn()
    {
        tutPanel[1].SetActive(false);
        tutPanel[2].SetActive(true);
        tutPanel[3].SetActive(false);
        tutPanel[4].SetActive(true);
        tutPanel[5].SetActive(false);
        tutPanel[6].SetActive(true);
    }

    public void TutBuildersBtn()
    {
        tutPanel[1].SetActive(false);
        tutPanel[2].SetActive(false);
        tutPanel[3].SetActive(true);
        tutPanel[4].SetActive(true);
        tutPanel[5].SetActive(true);
        tutPanel[6].SetActive(false);
    }
}
