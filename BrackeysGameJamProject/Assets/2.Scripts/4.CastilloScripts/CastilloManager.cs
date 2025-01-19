using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CastilloManager : MonoBehaviour
{
    [Header("PANELES LLAMADOS")]
    //[SerializeField] private GameObject panelCreacionPersonajes;
    [SerializeField] private GameObject textNeedBuilders;
    [SerializeField] private GameObject castilloInfoOpenImg;
    [SerializeField] private Animator pestProdAnim;
    [SerializeField] private GameObject infoCiudadanos;
    [SerializeField] private Animator infoCiudadanosAnim;

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
        infoCiudadanosAnim = infoCiudadanos.GetComponent<Animator>();
    }

    private void Update()
    {
        CheckTimeForButtons();
    }

    private void OnMouseDown()
    {
        CastilloInfoOpen();
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

    public void OpenInfoCiudadanos()
    {
        infoCiudadanosAnim.SetBool("InfoCitOut", true);
    }

    public void CloseInfoCiudadanos()
    {
        infoCiudadanosAnim.SetBool("InfoCitOut", false);
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
