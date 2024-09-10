using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarosStats : MonoBehaviour
{
    [SerializeField] private GameObject panelEstadisticas;

    void OnMouseDown()
    {
        MostrarEstadisticas();
    }

    void MostrarEstadisticas()
    {
        panelEstadisticas.SetActive(!panelEstadisticas.activeSelf);
    }
}
