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
    [SerializeField] private GameObject manecillaObj;

    private int dayTimeMin = 12;
    private int dayTimeSec = 0;

    private float rotationAmount = 90f;
    public int DayTimeMin 
    { 
        get { return dayTimeMin; }
        set
        {
            dayTimeMin = Mathf.Max(0, value);
            ActualizarTexto();
            ActualizarManecillas();
        } 
    }

    void Start()
    {
        ActualizarTexto();
        ActualizarManecillas();
    }

    private void ActualizarManecillas()
    {
        rotationAmount = 90f - ((dayTimeMin-12f) * -15f);
        manecillaObj.transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);
        //Debug.Log("ManecillaActualizada");
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
        ActualizarManecillas();
    }
}
