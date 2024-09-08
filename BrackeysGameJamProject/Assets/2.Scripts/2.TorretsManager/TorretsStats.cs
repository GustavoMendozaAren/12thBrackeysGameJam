using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretsStats : MonoBehaviour
{
    [SerializeField] private GameObject panelEstadisticas;  // El panel de UI que muestra las estad�sticas

    void OnMouseDown()
    {
        MostrarEstadisticas();
    }

    void MostrarEstadisticas()
    {
        panelEstadisticas.SetActive(!panelEstadisticas.activeSelf);
    }
}
