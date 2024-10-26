using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoAldeanoPnl : MonoBehaviour
{
    [SerializeField] private GameObject openPanelInfo;
    [SerializeField] private GameObject panelInfoFaro;
    [SerializeField] private GameObject panelInfoArqueros;

    [SerializeField] private Animator animator;

    private void Start()
    {
        animator = openPanelInfo.GetComponent<Animator>();
    }

    public void InfoFarosBttn()
    {
        panelInfoFaro.SetActive(!panelInfoFaro.activeSelf);
    }

    public void InfoArchersBttn()
    {
        panelInfoArqueros.SetActive(!panelInfoArqueros.activeSelf);
    }

    public void OpenPanelBttn()
    {
        animator.SetBool("InfoActive", true);
    }

    public void ClosePanelBttn()
    {
        animator.SetBool("InfoActive", false);
    }
}
