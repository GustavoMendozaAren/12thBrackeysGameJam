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
    [SerializeField] private GameObject playTxtObj;
    [SerializeField] private GameObject personsObj;

    [Header("ANIMATORS")]
    [SerializeField] private Animator logoCentralAnim;
    [SerializeField] private Animator lunaAnim;
    [SerializeField] private Animator solAnim;
    [SerializeField] private Animator optionsTxtAnim;
    [SerializeField] private Animator creditsTxtAnim;
    [SerializeField] private Animator playTxtAnim;
    [SerializeField] private Animator personsAnim;

    [Header("BOTONES")]
    [SerializeField] private GameObject backBttn;

    [Header("SLIDERS OBJ")]
    [SerializeField] private GameObject sliderMaster;
    [SerializeField] private GameObject sliderNarration;
    [SerializeField] private GameObject sliderMusic;
    [SerializeField] private GameObject sliderSfx;



    private void Start()
    {
        lunaAnim = lunaImage.GetComponent<Animator>();
        solAnim = solImage.GetComponent<Animator>();
        creditsTxtAnim = creditsTxtObj.GetComponent<Animator>();
        optionsTxtAnim = optionsTxtObj.GetComponent<Animator>();
        playTxtAnim = playTxtObj.GetComponent<Animator>();
        logoCentralAnim = logoCentralObj.GetComponent<Animator>();
        personsAnim = personsObj.GetComponent<Animator>();
    }
    public void PlayBttn()
    {
        mainMenuPanel.SetActive(false);

        playTxtAnim.SetBool("PlayTextOut", true);
        solAnim.SetBool("OutMainSol", true);
        lunaAnim.SetBool("OutMainLuna", true);

        logoCentralAnim.SetBool("CentralLogoOut", true);
        logoCentralAnim.SetBool("CentralLogoInMain", true);

        Invoke("PlayGameFunction", 3.5f);
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

        StartCoroutine(SlidersAppearingTime());
    }

    public void OptionsBttnExit()
    {
        StopCoroutine(SlidersAppearingTime());

        
        mainMenuPanel.SetActive(true);
        lunaAnim.SetBool("InOptions", false);

        solAnim.SetBool("OutMainSol", false);

        optionsTxtAnim.SetBool("OutOptionsPanel", true);
        optionsTxtAnim.SetBool("OptionsTextAcitve", false);

        logoCentralAnim.SetBool("CentralLogoOut", false);

        StartCoroutine(SlidersDeappearingTime());
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

    private void PlayGameFunction()
    {
        SceneManager.LoadScene("TestTorretas");
    }

    IEnumerator SlidersAppearingTime()
    {
        yield return new WaitForSeconds(2.25f);
        sliderMaster.SetActive(true);
        yield return new WaitForSeconds(.5f);
        sliderNarration.SetActive(true);
        yield return new WaitForSeconds(.5f);
        sliderMusic.SetActive(true);
        yield return new WaitForSeconds(.5f);
        sliderSfx.SetActive(true);

    }

    IEnumerator SlidersDeappearingTime()
    {
        yield return new WaitForSeconds(.20f);
        sliderMaster.SetActive(false);
        yield return new WaitForSeconds(.20f);
        sliderNarration.SetActive(false);
        yield return new WaitForSeconds(.20f);
        sliderMusic.SetActive(false);
        yield return new WaitForSeconds(.20f);
        sliderSfx.SetActive(false);
        yield return new WaitForSeconds(.20f);
        optionsPanel.SetActive(false);
    }
}
