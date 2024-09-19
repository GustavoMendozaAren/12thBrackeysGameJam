using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header ("PANELES")]
    [SerializeField] private GameObject mainMenuPanel, optionsPanel, creditsPanel;

    [Header ("OBJETOS")]
    [SerializeField] private GameObject lunaImage;
    [SerializeField] private GameObject solImage;

    [Header("ANIMATORS")]
    [SerializeField] private Animator lunaAnim;
    [SerializeField] private Animator solAnim;



    private void Start()
    {
        lunaAnim = lunaImage.GetComponent<Animator>();
        solAnim = solImage.GetComponent<Animator>();
    }
    public void PlayBttn()
    {
        SceneManager.LoadScene("TestScene1");
    }

    public void OptionsBttn()
    {
        optionsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        lunaAnim.SetBool("InOptions", true);

        solAnim.SetBool("OutMainSol", true);
    }

    public void OptionsBttnExit()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        lunaAnim.SetBool("InOptions", false);

        solAnim.SetBool("OutMainSol", false);
    }

    public void CreditsBttn()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        solAnim.SetBool("InCredits", true);

        lunaAnim.SetBool("OutMainLuna", true);
    }

    public void CreditsBttnExit()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        solAnim.SetBool("InCredits", false);

        lunaAnim.SetBool("OutMainLuna", false);
    }

    public void ExitBttn()
    {
        Application.Quit();
    }
}
