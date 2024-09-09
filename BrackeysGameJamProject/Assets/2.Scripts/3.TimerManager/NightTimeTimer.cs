using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NightTimeTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nightTimerText;
    [SerializeField] private GameObject endNightBttn;

    private float timeRemaining = 12 * 60;
    private bool timerIsRunning = false;

    private float timerSpeed = 4f;

    void OnEnable()
    {
        timerSpeed = 4f;
        timeRemaining = 12 * 60;
        endNightBttn.SetActive(false);
        timerIsRunning = true;
        UpdateTimerText();
    }

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
                UpdateTimerText();
                OnTimerEnd();
            }
        }
    }

    void UpdateTimerText()
    {
        // Obtener minutos y segundos restantes.
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Actualizar el texto de la UI.
        nightTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnTimerEnd()
    {
        endNightBttn.SetActive(true);
    }

    public void NormalSpeedBttn()
    {
        timerSpeed = 4f; 
    }

    public void DoubleSpeedBttn()
    {
        timerSpeed = 36f; 
    }
}
