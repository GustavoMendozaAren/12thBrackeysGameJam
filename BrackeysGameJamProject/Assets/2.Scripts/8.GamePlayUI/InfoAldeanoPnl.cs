using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoAldeanoPnl : MonoBehaviour
{
    [SerializeField] private GameObject openPanelInfo;
    [SerializeField] private GameObject panelInfoFaro;
    [SerializeField] private GameObject panelInfoArqueros;
    [SerializeField] private GameObject openWarriorInfoPanel;
    [SerializeField] private GameObject openBuilderInfoPanel;

    public void OpenInfoFarosBttn()
    {
        panelInfoFaro.SetActive(true);
    }

    public void CloseInfoFarosBttn()
    {
        panelInfoFaro.SetActive(false);
    }

    public void OpenInfoArchersBttn()
    {
        panelInfoArqueros.SetActive(true);
    }

    public void CloseInfoArchersBttn()
    {
        panelInfoArqueros.SetActive(false);
    }

    public void OpenWarriorInfo()
    {
        openWarriorInfoPanel.SetActive(true);
    }

    public void CloseWarriorInfo()
    {
        openWarriorInfoPanel.SetActive(false);
    }

    public void OpenBuilderInfo()
    {
        openBuilderInfoPanel.SetActive(true);
    }

    public void CloseBuilderInfo()
    {
        openBuilderInfoPanel.SetActive(false);
    }
}
