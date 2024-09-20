using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header ("PANELES")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("OBJETOS")]
    [SerializeField] private GameObject logoCentralObj;
    [SerializeField] private GameObject lunaImage;
    [SerializeField] private GameObject solImage;
    [SerializeField] private GameObject optionsTxtObj;
    [SerializeField] private GameObject creditsTxtObj;
    [SerializeField] private GameObject personsObj;

    [Header("ANIMATORS")]
    [SerializeField] private Animator logoCentralAnim;
    [SerializeField] private Animator lunaAnim;
    [SerializeField] private Animator solAnim;
    [SerializeField] private Animator optionsTxtAnim;
    [SerializeField] private Animator creditsTxtAnim;
    [SerializeField] private Animator personsAnim;

    [Header("BOTONES")]
    [SerializeField] private GameObject backBttn;



    private void Start()
    {
        lunaAnim = lunaImage.GetComponent<Animator>();
        solAnim = solImage.GetComponent<Animator>();
        creditsTxtAnim = creditsTxtObj.GetComponent<Animator>();
        optionsTxtAnim = optionsTxtObj.GetComponent<Animator>();
        logoCentralAnim = logoCentralObj.GetComponent<Animator>();
        personsAnim = personsObj.GetComponent<Animator>();
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

        optionsTxtAnim.SetBool("OutOptionsPanel", false);
        optionsTxtAnim.SetBool("OptionsTextAcitve", true);

        logoCentralAnim.SetBool("CentralLogoOut", true);
        logoCentralAnim.SetBool("CentralLogoInMain", true);
    }

    public void OptionsBttnExit()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        lunaAnim.SetBool("InOptions", false);

        solAnim.SetBool("OutMainSol", false);

        optionsTxtAnim.SetBool("OutOptionsPanel", true);
        optionsTxtAnim.SetBool("OptionsTextAcitve", false);

        logoCentralAnim.SetBool("CentralLogoOut", false);

    }

    public void CreditsBttn()
    {
        backBttn.SetActive(true);
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        solAnim.SetBool("InCredits", true);

        lunaAnim.SetBool("OutMainLuna", true);

        creditsTxtAnim.SetBool("OutCreditsPanel", false);
        creditsTxtAnim.SetBool("CreditsTxtActive", true);

        logoCentralAnim.SetBool("CentralLogoOut", true);
        logoCentralAnim.SetBool("CentralLogoInMain", true);

        personsAnim.SetBool("PersonasCreditsOut", false);

    }

    public void CreditsBttnExit()
    {
        backBttn.SetActive(false);
        mainMenuPanel.SetActive(true);
        solAnim.SetBool("InCredits", false);

        lunaAnim.SetBool("OutMainLuna", false);

        creditsTxtAnim.SetBool("OutCreditsPanel", true);
        creditsTxtAnim.SetBool("CreditsTxtActive", false);

        logoCentralAnim.SetBool("CentralLogoOut", false);

        personsAnim.SetBool("PersonasCreditsOut", true);

        Invoke("DeactiveCreditsPanel", 1.5f);
    }

    public void ExitBttn()
    {
        Application.Quit();
    }

    private void DeactiveCreditsPanel()
    {
        creditsPanel.SetActive(false);
    }
}
