using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EndTurnButtons : MonoBehaviour
{
    [SerializeField] private GameObject dayButtonsPanel, nightButtonsPanel, inactiveProdBttn;

    [SerializeField] private Light2D globalLight;
    private float lightFadeDuration = 3f;
    private bool isFadingDown = false;
    private bool isFadingUp = false;

    [SerializeField] private TextMeshProUGUI daysTxt;
    [SerializeField] private GameObject daysTxtObj;
    [SerializeField] private TextMeshProUGUI spareBuildersTxt;

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
        inactiveProdBttn.SetActive(true);
        dayButtonsPanel.SetActive(false);
        nightButtonsPanel.SetActive(true);
        isFadingDown = true;

        StaticVariables.cantidadBuildersDisponibles = StaticVariables.cantidadBuildersTotales;
        
        spareBuildersTxt.text = "" + StaticVariables.cantidadBuildersDisponibles;

        ActivarCollidersTorres();

        daysTxtObj.SetActive(false);
    }

    public void EndNightButton()
    {
        inactiveProdBttn.SetActive(false);
        dayButtonsPanel.SetActive(true);
        nightButtonsPanel.SetActive(false);
        isFadingUp = true;

        ActualizarLuzDeTorres();

        ActualizarAldeanosMuertosDeTorre();

        Invoke(nameof(DesactivarColliderTorres), 1f);

        daysTxtObj.SetActive(true);
        StaticVariables.diasTranscurridos++;
        daysTxt.text = "DAY " + StaticVariables.diasTranscurridos;
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

    void ActualizarLuzDeTorres()
    {
        FarosStats[] farosStats = FindObjectsOfType<FarosStats>();

        // Actualiza la luz de cada torreta de faro
        foreach (FarosStats faro in farosStats)
        {
            faro.ActualizarFarosLight();
        }
    }

    void ActualizarAldeanosMuertosDeTorre()
    {
        TorretsStats[] torreStats = FindObjectsOfType<TorretsStats>();

        foreach (TorretsStats arqueros in torreStats)
        {
            arqueros.ActualizarAldeanosMuertos();
        }
        
    }

    void ActivarCollidersTorres()
    {
        FarosStats farosStats = FindObjectOfType<FarosStats>();
        if (farosStats != null)
        {
            farosStats.farosCollider.enabled = true;
            Debug.Log("Colliders Activados");
        }
    }

    void DesactivarColliderTorres()
    {
        FarosStats farosStats = FindObjectOfType<FarosStats>();

        if (farosStats != null)
        {
            farosStats.farosCollider.enabled = false;
            Debug.Log("CollidersDesactivados");
        }
    }
}
