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

    private int dayTimeMin = 12;
    private int dayTimeSec = 0;
    public int DayTimeMin 
    { 
        get { return dayTimeMin; }
        set
        {
            dayTimeMin = Mathf.Max(0, value);
            ActualizarTexto();
        } 
    }

    void Start()
    {
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        //timerTxt.text = dayTimeMin + "H";
        timerTxt.text = string.Format("{0:00}:{1:00}", dayTimeMin, dayTimeSec);
    }

    public void RestartDayHours()
    {
        dayTimeMin = 12;
        ActualizarTexto();
    }
}
