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

    private float rotationAmount2 = 0f;
    public int DayTimeMin 
    { 
        get { return dayTimeMin; }
        set
        {
            dayTimeMin = Mathf.Max(0, value);
            ActualizarTexto();
            ActualizarNuevasManecillas();
        } 
    }

    void Start()
    {
        ActualizarTexto();
        ActualizarNuevasManecillas();
    }

    private void ActualizarNuevasManecillas()
    {
        rotationAmount2 = ((dayTimeMin - 12f) * 15f);
        manecillaObj.transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount2);
    }

    private void ActualizarTexto()
    {
        timerTxt.text = string.Format($"{dayTimeMin}");
    }

    public void RestartDayHours()
    {
        dayTimeMin = 12;
        ActualizarTexto();
        ActualizarNuevasManecillas();
    }
}
