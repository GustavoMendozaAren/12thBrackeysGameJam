using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CastilloManager : MonoBehaviour
{
    [Header("PANELES LLAMADOS")]
    [SerializeField] private GameObject panelCreacionPersonajes;
    private SpriteRenderer spriteRenderer;

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
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (timerManagerCastillo.DayTimeMin < 2)
            panelCreacionPersonajes.SetActive(false);
        else
            return;
    }

    void OnMouseDown()
    {
        CheckTimeForButtons();

        if (timerManagerCastillo.DayTimeMin < 2)
            return;
        else
            MostrarPanelCreacion();
    }

    private void OnMouseEnter()
    {
        CambiarAlpha(0.8f);
    }

    void OnMouseExit()
    {
        CambiarAlpha(1f);  // Cambia el alpha de vuelta a 1
    }

    void MostrarPanelCreacion()
    {
        panelCreacionPersonajes.SetActive(!panelCreacionPersonajes.activeSelf);
    }

    // Método para cambiar el alpha del color del SpriteRenderer
    void CambiarAlpha(float alphaValue)
    {
        if (spriteRenderer != null)
        {
            Color colorActual = spriteRenderer.color;
            colorActual.a = alphaValue;  // Cambia el valor del alpha
            spriteRenderer.color = colorActual;  // Asigna el nuevo color
        }
    }

    public void AldenosCreationBttn()
    {
        if (StaticVariables.cantidadAldeanosTotales < 10 && timerManagerCastillo.DayTimeMin >= 2) 
        {
            timerManagerCastillo.DayTimeMin -= 2;
            StaticVariables.cantidadAldeanosTotales++;
            aldenosTxt.text = "" + StaticVariables.cantidadAldeanosTotales;
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
            buildersTxt.text = "" + StaticVariables.cantidadBuildersTotales;
            CheckTimeForButtons();

            StaticVariables.cantidadBuildersDisponibles++;
            spareBuilders.text = "" + StaticVariables.cantidadBuildersDisponibles;
        }
        else
        {
            return;
        }
    }

    void CheckTimeForButtons()
    {
        if (timerManagerCastillo.DayTimeMin < 2)
            panelCreacionPersonajes.SetActive(false);
        else
            return;
    }
}
