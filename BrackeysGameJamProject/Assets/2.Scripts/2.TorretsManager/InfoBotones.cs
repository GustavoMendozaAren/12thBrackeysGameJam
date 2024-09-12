using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBotones : MonoBehaviour
{
    [SerializeField] private GameObject panelInfoFaro;
    [SerializeField] private GameObject panelInfoArqueros;

    public void InfoFarosBttn()
    {
        panelInfoFaro.SetActive(!panelInfoFaro.activeSelf);
    }

    public void InfoArchersBttn()
    {
        panelInfoArqueros.SetActive(!panelInfoArqueros.activeSelf);
    }
}
