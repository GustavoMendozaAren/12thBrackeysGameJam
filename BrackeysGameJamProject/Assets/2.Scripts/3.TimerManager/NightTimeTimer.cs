using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NightTimeTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nightTimerText;
    [SerializeField] private GameObject manecillaNightObj;
    [SerializeField] private GameObject endNightBttn;

    private float timeRemaining = 190f;
    private bool timerIsRunning = false;
    private float timerSpeed = 1f;

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
            UpdateTimerText();
        }

        if (nightTimerIsRunning)
        {
            ActualizarManecillasNight();
        }

    }

    void UpdateTimerText()
    {
        minutes = (int)timeRemaining / 15;
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime * timerSpeed;
            nightTimerText.text = string.Format($"{minutes}");
        }
        else
        {
            timeRemaining = 0;
            timerIsRunning = false;
            nightTimerText.text = string.Format($"{minutes}");
            OnTimerEnd();
        }
        
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
        timerSpeed = 1.5f;
        nighttimerSpeed = 1.5f;
        StaticVariables.enemiesSpeed = 1;
        StaticVariables.proyectileSpeed = 10f;
        StaticVariables.rateOfFire = 1f;
    }

    public void DoubleSpeedBttn()
    {
        timerSpeed = 3f;
        nighttimerSpeed = 3f;
        StaticVariables.enemiesSpeed = 2;
        StaticVariables.proyectileSpeed = 5f;
        StaticVariables.rateOfFire = 0.5f;
    }

    public void ResertNightTimerBttn()
    {
        timerSpeed = 1.5f;
        nighttimerSpeed = 1.5f;
        StaticVariables.enemiesSpeed = 1;
        StaticVariables.proyectileSpeed = 10f;
        StaticVariables.rateOfFire = 1f;

        timeRemaining = 190f;
        endNightBttn.SetActive(false);
        nightCounter = -90f;
        timerIsRunning = true;
        nightTimerIsRunning = true;
        UpdateTimerText();
    }
}
