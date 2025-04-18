using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class FarosStats : MonoBehaviour
{
    [Header("PANELES LLAMADOS")]
    [SerializeField] private GameObject openedInfoPanel;
    [SerializeField] private GameObject closedInfoPanel;

    [Header("TEXTOS LLAMADOS")]
    [SerializeField] private TextMeshProUGUI fuelTxt;
    private int fuel = 3;

    [SerializeField] private Light2D towerFaroLight;

    public CircleCollider2D farosCollider;

    /*void OnMouseDown()
    {
        panelEstadisticas.SetActive(!panelEstadisticas.activeSelf);
    }

    private void OnMouseEnter()
    {
        panelEstadisticas.SetActive(true);
    }
    */

    public void ActualizarFarosLight()
    {
        if (towerFaroLight != null)
        {
            towerFaroLight.pointLightOuterRadius -= 1f;
            farosCollider.radius--;
            fuel--;
            ActualizarTextosFuel();

            if (towerFaroLight.pointLightOuterRadius < 1f)
                towerFaroLight.pointLightOuterRadius = .3f;

            if (farosCollider.radius < 1f)
                farosCollider.radius = .3f;
        }
        else
        {
            Debug.LogWarning("Light2D component not assigned to the FarosTower script.");
        }
    }

    public void AumentarElFuelBttn()
    {
        if(towerFaroLight.pointLightOuterRadius < 3.3f)
        {
            if(StaticVariables.cantidadBuildersDisponibles > 0)
            {
                towerFaroLight.pointLightOuterRadius += 1f;
                farosCollider.radius++;
                fuel++;
                StaticVariables.cantidadBuildersDisponibles--;
                ActualizarTextosFuel();

                TextMeshProUGUI spareBuildersTxt = GameObject.Find("BuildersDisponibles_Txt").GetComponent<TextMeshProUGUI>();
                spareBuildersTxt.text = "" + StaticVariables.cantidadBuildersDisponibles;
            }
        }
    }

    public void InfoOpenPanelBtttn()
    {
        openedInfoPanel.SetActive(true);
        closedInfoPanel.SetActive(false);
    }

    public void InfoClosePanelBtttn()
    {
        openedInfoPanel.SetActive(false);
        closedInfoPanel.SetActive(true);
    }

    void ActualizarTextosFuel()
    {
        fuelTxt.text = fuel + "/3";
    }

}
