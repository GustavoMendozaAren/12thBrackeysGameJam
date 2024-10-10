using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NightTimeTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nightTimerText;
    [SerializeField] private GameObject manecillaNightObj;
    [SerializeField] private GameObject endNightBttn;

    private float timeRemaining = 12f * 60f;
    private bool timerIsRunning = false;

    private float timerSpeed = 4f;

    int minutes;
    int seconds;

    // Manecillas Variables
    private float nightCounter = -90f;
    private bool nightTimerIsRunning = false;
    private float nighttimerSpeed = 1f;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Restar el tiempo transcurrido.
                timeRemaining -= Time.deltaTime * timerSpeed;
                UpdateTimerText();            
            }
            else
            {
                // Detener el temporizador y llamar a la función.
                timeRemaining = 0;
                timerIsRunning = false;

                nightTimerText.text = string.Format($"{minutes + 1}");
                OnTimerEnd();
            }
        }

        if (nightTimerIsRunning)
        {
            ActualizarManecillasNight();
        }

    }

    void UpdateTimerText()
    {
        // Obtener minutos y segundos restantes.
        minutes = Mathf.FloorToInt(timeRemaining / 60);
        seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Actualizar el texto de la UI.
        nightTimerText.text = string.Format($"{minutes + 1}");
    }

    private void ActualizarManecillasNight()
    {
        if(nightCounter > -270f)
        {
            nightCounter -= Time.deltaTime * nighttimerSpeed;
            manecillaNightObj.transform.rotation = Quaternion.Euler(0f, 0f, nightCounter);
        }
        else
        {
            nightCounter = -270f;
            manecillaNightObj.transform.rotation = Quaternion.Euler(0f, 0f, nightCounter);
            nightTimerIsRunning = false;
            OnTimerEnd();
        }
        //Debug.Log("ManecillaActualizada");
    }

    void OnTimerEnd()
    {
        endNightBttn.SetActive(true);
    }

    public void NormalSpeedBttn()
    {
        timerSpeed = 4f;
        nighttimerSpeed = 1f;
    }

    public void DoubleSpeedBttn()
    {
        timerSpeed = 48f;
        nighttimerSpeed = 12f;
    }

    public void ResertNightTimerBttn()
    {
        timerSpeed = 4f;
        timeRemaining = 12 * 60;
        endNightBttn.SetActive(false);
        nightCounter = -90f;
        timerIsRunning = true;
        nightTimerIsRunning = true;
        UpdateTimerText();
    }
}
