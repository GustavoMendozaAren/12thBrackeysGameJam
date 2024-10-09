using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoAldeanoPnl : MonoBehaviour
{
    [SerializeField] private GameObject openPanelInfo;
    [SerializeField] private GameObject closePanelInfo;

    public void OpenPanelBttn()
    {
        openPanelInfo.SetActive(true);
        closePanelInfo.SetActive(false);
    }

    public void ClosePanelBttn()
    {
        openPanelInfo.SetActive(false);
        closePanelInfo.SetActive(true);
    }
}
