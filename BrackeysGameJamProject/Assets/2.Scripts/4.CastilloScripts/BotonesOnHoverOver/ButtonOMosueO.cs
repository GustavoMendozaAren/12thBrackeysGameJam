using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonOMosueO : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private int id; // 1-Builders, 2-Warriors, 3-Arqueros, 4-Faro

    private bool mouse_over = false;

    public InfoAldeanoPnl infoAldeanos;

    void Update()
    {
        if (mouse_over && id == 1)
        {
            infoAldeanos.OpenBuilderInfo();
        }
        if (mouse_over && id == 2)
        {
            infoAldeanos.OpenWarriorInfo();
        }
        if (mouse_over && id == 3)
        {
            infoAldeanos.OpenInfoArchersBttn();
        }
        if (mouse_over && id == 4)
        {
            infoAldeanos.OpenInfoFarosBttn(); ;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
    }
}
