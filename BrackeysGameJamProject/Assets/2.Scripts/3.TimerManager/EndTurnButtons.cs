using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EndTurnButtons : MonoBehaviour
{
    [SerializeField] private GameObject dayButtonsPanel, nightButtonsPanel;

    [SerializeField] private Light2D globalLight;
    private float lightFadeDuration = 5f;
    private bool isFadingDown = false;
    private bool isFadingUp = false;

    private void Update()
    {
        if (isFadingDown)
        {
            FadeLightDown();
        }
        if (isFadingUp)
        {
            FadeLightUp();
        }
    }

    public void EndDayButton()
    {
        dayButtonsPanel.SetActive(false);
        nightButtonsPanel.SetActive(true);
        isFadingDown = true;
    }

    public void EndNightButton()
    {
        dayButtonsPanel.SetActive(true);
        nightButtonsPanel.SetActive(false);
        isFadingUp = true;
    }

    void FadeLightDown()
    {
        // Reducir la intensidad de la luz de manera gradual durante los 10 segundos.
        if (globalLight.intensity > 0.01f)
        {
            // Gradualmente disminuir la intensidad de 1 a 0.1 en lightFadeDuration segundos.
            globalLight.intensity -= (1f - 0.01f) / lightFadeDuration * Time.deltaTime;
        }
        else
        {
            // Detener el proceso de fade cuando se alcance la intensidad deseada.
            globalLight.intensity = 0.01f;
            isFadingDown = false;
        }
    }

    void FadeLightUp()
    {
        if (globalLight.intensity < 1f)
        {
            // Gradualmente disminuir la intensidad de 1 a 0.1 en lightFadeDuration segundos.
            globalLight.intensity += (0.01f + 1f) / lightFadeDuration * Time.deltaTime;
        }
        else
        {
            // Detener el proceso de fade cuando se alcance la intensidad deseada.
            globalLight.intensity = 1f;
            isFadingUp = false;
        }
    }
}
