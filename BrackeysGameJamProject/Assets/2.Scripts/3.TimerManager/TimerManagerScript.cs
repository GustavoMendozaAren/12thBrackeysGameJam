using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;

public class TimerManagerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTxt;
    [SerializeField] private GameObject noMoreTimeTxt, buildBttn;

    private int dayTime = 12;
    public int DayTime 
    { 
        get { return dayTime; }
        set
        {
            dayTime = Mathf.Max(0, value);
            ActualizarTexto();

            // Si el tiempo llega a 0, mostrar el mensaje de "Se acabó el tiempo"
            if (dayTime == 0)
            {
                noMoreTimeTxt.SetActive(true);
            }
            if (dayTime < 3)
            {
                buildBttn.SetActive(false);
            }
        } 
    }
    private void ActualizarTexto()
    {
        timerTxt.text = dayTime + "H";
    }
    void Start()
    {
        ActualizarTexto();

        noMoreTimeTxt.SetActive(false);
        buildBttn.SetActive(true);
    }

}
