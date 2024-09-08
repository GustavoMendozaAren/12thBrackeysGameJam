using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel, optionsPanel, creditsPanel;
    public void PlayBttn()
    {
        SceneManager.LoadScene("TestScene1");
    }

    public void OptionsBttn()
    {
        optionsPanel.SetActive(!optionsPanel.activeSelf);
        mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
    }

    public void CreditsBttn()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
        mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
    }

    public void ExitBttn()
    {
        Application.Quit();
    }
}
