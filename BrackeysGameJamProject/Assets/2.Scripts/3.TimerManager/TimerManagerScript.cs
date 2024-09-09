using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;

public class TimerManagerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerTxt;
    [SerializeField] private GameObject buildBttn;

    private int dayTimeMin = 12;
    private int dayTimeSec = 0;
    public int DayTimeMin 
    { 
        get { return dayTimeMin; }
        set
        {
            dayTimeMin = Mathf.Max(0, value);
            ActualizarTexto();

            TimeOverCondition();
        } 
    }

    void Start()
    {
        ActualizarTexto();

        buildBttn.SetActive(true);
    }

    private void ActualizarTexto()
    {
        //timerTxt.text = dayTimeMin + "H";
        timerTxt.text = string.Format("{0:00}:{1:00}", dayTimeMin, dayTimeSec);
    }

    private void TimeOverCondition()
    {
        if (dayTimeMin < 3)
        {
            buildBttn.SetActive(false);
        }
    }

    public void RestartDayHours()
    {
        if (dayTimeMin == 0)
        {
            dayTimeMin = 12;
            ActualizarTexto();
            buildBttn.SetActive(true);
        }
    }
}
