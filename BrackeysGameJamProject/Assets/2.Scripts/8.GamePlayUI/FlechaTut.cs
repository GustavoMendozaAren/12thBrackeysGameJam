using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FlechaTut : MonoBehaviour
{
    [Header("FLECHAS")]
    [SerializeField] private GameObject flecha1;
    [SerializeField] private GameObject flecha2;
    [SerializeField] private GameObject flecha3;
    [SerializeField] private GameObject flechaManager;

    public void Flecha1Bttn()
    {
        flecha1.SetActive(false);
        flecha2.SetActive(true);
    }

    public void Flecha2Bttn()
    {
        flecha2.SetActive(false);
        flecha3.SetActive(true);
    }

    public void Flecha3Bttn()
    {
        flecha3.SetActive(false);
        flechaManager.SetActive(false);
    }
}
