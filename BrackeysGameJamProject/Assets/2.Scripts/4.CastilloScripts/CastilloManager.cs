using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastilloManager : MonoBehaviour
{
    [SerializeField] private GameObject panelCreacionPersonajes;
    [SerializeField] private GameObject aldeanoBttn, builderBttn;
    private SpriteRenderer spriteRenderer;

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
        CheckTimeForButtons();
    }

    public void BuilderCreationBttn()
    {
        timerManagerCastillo.DayTimeMin -= 2;
        CheckTimeForButtons();
    }

    void CheckTimeForButtons()
    {
        if(timerManagerCastillo.DayTimeMin < 2)
        {
            aldeanoBttn.SetActive(false);
            builderBttn.SetActive(false);
        }
        else 
        {
            aldeanoBttn.SetActive(true);
            builderBttn.SetActive(true);
        }
    }
}
