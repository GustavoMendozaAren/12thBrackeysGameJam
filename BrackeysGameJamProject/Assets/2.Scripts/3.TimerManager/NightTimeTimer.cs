using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NightTimeTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nightTimerText;
    [SerializeField] private GameObject manecillaNightObj;
    [SerializeField] private GameObject endNightBttn;

    private float timeRemaining = 180f;
    private bool timerIsRunning = false;
    private float timerSpeed = 1f;

    int minutes;

    // Manecillas Variables
    private float nightCounter2 = 180f;
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
            ActualizarManecillasNightNuevas();
        }

    }

    void UpdateTimerText()
    {
        minutes = (int)timeRemaining / 15;
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime * timerSpeed;
            nightTimerText.text = string.Format($"{minutes}");
        }
        else
        {
            timeRemaining = 0f;
            timerIsRunning = false;
            nightTimerText.text = string.Format($"0");
            OnTimerEnd();
        }
        
    }

    private void ActualizarManecillasNightNuevas()
    {
        if (nightCounter2 > 0f)
        {
            nightCounter2 -= Time.deltaTime * nighttimerSpeed;
            manecillaNightObj.transform.rotation = Quaternion.Euler(0f, 0f, nightCounter2);
        }
        else
        {
            nightCounter2 = 0f;
            manecillaNightObj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            nightTimerIsRunning = false;
            OnTimerEnd();
        }
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

    public void CuatrupleSpeedBttn()
    {
        timerSpeed = 6f;
        nighttimerSpeed = 6f;
        StaticVariables.enemiesSpeed = 4;
        StaticVariables.proyectileSpeed = 2.5f;
        StaticVariables.rateOfFire = 0.25f;
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
        nightCounter2 = 180f;
        timerIsRunning = true;
        nightTimerIsRunning = true;
    }
}
