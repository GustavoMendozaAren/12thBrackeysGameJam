using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject controlsInfoPanel;

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
    }

    public void MainMenuBttn()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1f;
    }

    public void OptionsBttn()
    {

    }

    public void CloseControlsInfoPanel()
    {
        controlsInfoPanel.SetActive(false);
    }
}
