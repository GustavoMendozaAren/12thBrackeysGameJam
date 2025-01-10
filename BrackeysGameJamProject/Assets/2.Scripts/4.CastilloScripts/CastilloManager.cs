using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CastilloManager : MonoBehaviour
{
    [Header("PANELES LLAMADOS")]
    //[SerializeField] private GameObject panelCreacionPersonajes;
    [SerializeField] private GameObject openWarriorInfoPanel;
    [SerializeField] private GameObject openBuilderInfoPanel;
    [SerializeField] private GameObject textNeedBuilders;
    [SerializeField] private GameObject castilloInfoOpenImg;
    [SerializeField] private Animator pestProdAnim;
    [SerializeField] private GameObject infoCiudadanos;

    [Header("TEXTOS")]
    [SerializeField] private TextMeshProUGUI aldenosTxt;
    [SerializeField] private TextMeshProUGUI buildersTxt;

    [Header("DISPONIBLES TXT")]
    [SerializeField] private TextMeshProUGUI spareAldeanos;
    [SerializeField] private TextMeshProUGUI spareBuilders;

    [Header("SCRIPTS LLAMADOS")]
    [SerializeField] private TimerManagerScript timerManagerCastillo;

    void Start()
    {
        pestProdAnim = castilloInfoOpenImg.GetComponent<Animator>();
    }

    private void Update()
    {
        CheckTimeForButtons();
    }

    void CheckTimeForButtons()
    {
        if (timerManagerCastillo.DayTimeMin < 2)
        {
            castilloInfoOpenImg.SetActive(false);
        }
        else
        {
            return;
        }
            
    }

    public void AldenosCreationBttn()
    {
        if (StaticVariables.cantidadAldeanosTotales < 10 && timerManagerCastillo.DayTimeMin >= 2) 
        {
            timerManagerCastillo.DayTimeMin -= 2;
            StaticVariables.cantidadAldeanosTotales++;
            aldenosTxt.text = StaticVariables.cantidadAldeanosTotales + "/10";
            CheckTimeForButtons();

            StaticVariables.cantidadAldeanosDisponibles++;
            spareAldeanos.text = "" + StaticVariables.cantidadAldeanosDisponibles;
        }
        else
        {
            return;
        }
    }

    public void BuilderCreationBttn()
    {
        if (StaticVariables.cantidadBuildersTotales < 5 && timerManagerCastillo.DayTimeMin >= 2) 
        {
            timerManagerCastillo.DayTimeMin -= 2;
            StaticVariables.cantidadBuildersTotales++;
            buildersTxt.text = StaticVariables.cantidadBuildersTotales + "/5";
            CheckTimeForButtons();

            StaticVariables.cantidadBuildersDisponibles++;
            spareBuilders.text = "" + StaticVariables.cantidadBuildersDisponibles;
        }
        else
        {
            return;
        }
    }

    public void CastilloInfoOpen()
    {
        pestProdAnim.SetBool("ProdIn", true);
    }

    public void CastilloInfoClose()
    {
        pestProdAnim.SetBool("ProdIn", false);
    }

    public void OpenCloseInfoCiudadanos()
    {
        infoCiudadanos.SetActive(!infoCiudadanos.activeSelf);
    }

    public void OpenWarriorInfo()
    {
        openWarriorInfoPanel.SetActive(!openWarriorInfoPanel.activeSelf);
    }

    public void OpenBuilderInfo()
    {
        openBuilderInfoPanel.SetActive(!openBuilderInfoPanel.activeSelf);
        
    }

    public void NeedBuildersText()
    {
        StartCoroutine(TextNeedB());
    }

    IEnumerator TextNeedB()
    {
        textNeedBuilders.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        textNeedBuilders.SetActive(false);
    }
}
