using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CastilloManager : MonoBehaviour
{
    [SerializeField] private GameObject panelCreacionPersonajes;
    private SpriteRenderer spriteRenderer;
    private bool panelBloqueado = false;

    [Header("TEXTOS")]
    [SerializeField] private TextMeshProUGUI aldenosTxt;
    [SerializeField] private TextMeshProUGUI buildersTxt;
    private int aldeanosNumber = 0;
    private int buildersNumber = 0;

    [Header("DISPONIBLES TXT")]
    [SerializeField] private TextMeshProUGUI spareAldeanos;

    [Header("SCRIPTS LLAMADOS")]
    [SerializeField] private TimerManagerScript timerManagerCastillo;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        MostrarPanelCreacion();

        CheckTimeForButtons();
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
        if (panelBloqueado)
            return;
        else
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
        timerManagerCastillo.DayTimeMin -= 2;
        aldeanosNumber++;
        aldenosTxt.text = "ALDEANOS: " + aldeanosNumber;
        CheckTimeForButtons();

        StaticVariables.cantidadAldeanosDisponibles++;
        spareAldeanos.text = "SPARE: " + StaticVariables.cantidadAldeanosDisponibles;
    }

    public void BuilderCreationBttn()
    {
        timerManagerCastillo.DayTimeMin -= 2;
        buildersNumber++;
        buildersTxt.text = "BUILDERS: " + buildersNumber;
        CheckTimeForButtons();
    }

    void CheckTimeForButtons()
    {
        if(timerManagerCastillo.DayTimeMin < 2)
        {
            panelBloqueado = true;
            panelCreacionPersonajes.SetActive(false);
        }
        else 
        {
            panelBloqueado = false;
        }
    }
}
