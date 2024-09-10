using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;

public class TimerManagerScript : MonoBehaviour
{
    [Header("TEXTOS")]
    [SerializeField] private TextMeshProUGUI timerTxt;

    [Header("BOTONES")]
    [SerializeField] private GameObject archersBttn;
    [SerializeField] private GameObject faroBttn;

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

        archersBttn.SetActive(true);
        faroBttn.SetActive(true);
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
            archersBttn.SetActive(false);
            faroBttn.SetActive(false);
        }
    }

    public void RestartDayHours()
    {
        if (dayTimeMin == 0)
        {
            dayTimeMin = 12;
            ActualizarTexto();
            archersBttn.SetActive(true);
            faroBttn.SetActive(true);
        }
    }
}
