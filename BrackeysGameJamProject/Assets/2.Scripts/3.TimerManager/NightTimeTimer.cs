using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NightTimeTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nightTimerText;
    [SerializeField] private GameObject manecillaNightObj;
    [SerializeField] private GameObject endNightBttn;

    private float timeRemaining = 130f;
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
        minutes = (int)timeRemaining / 10;
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
        timerSpeed = 1f;
        nighttimerSpeed = 1f;
    }

    public void DoubleSpeedBttn()
    {
        timerSpeed = 8f;
        nighttimerSpeed = 12f;
    }

    public void ResertNightTimerBttn()
    {
        timerSpeed = 1f;
        nighttimerSpeed = 1f;

        timeRemaining = 130f;
        endNightBttn.SetActive(false);
        nightCounter = -90f;
        timerIsRunning = true;
        nightTimerIsRunning = true;
        UpdateTimerText();
    }
}
