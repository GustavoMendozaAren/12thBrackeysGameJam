using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject controlsInfoPanel;

    private void Start()
    {
        Time.timeScale = 0f;
    }
    public void PauseBttn()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PauseBttnBack()
    {
        pausePanel.SetActive(false);
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

    }

    private void ResetVariables()
    {
        StaticVariables.diasTranscurridos = 1;
        StaticVariables.cantidadAldeanosTotales = 0;
        StaticVariables.cantidadAldeanosDisponibles = 0;
        StaticVariables.cantidadBuildersTotales = 0;
        StaticVariables.cantidadBuildersDisponibles = 0;
}

    public void CloseControlsInfoPanel()
    {
        controlsInfoPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
