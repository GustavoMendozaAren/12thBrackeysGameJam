using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notificaciones : MonoBehaviour
{
    [SerializeField] private GameObject dNotification;
    [SerializeField] private GameObject dNotificationBig;
    [SerializeField] private TextMeshProUGUI cantidadTxt;

    public void ActiveDeathNotiication()
    {
        dNotification.SetActive(true);
    }

    public void DeactiveDeathNotification()
    {
        dNotification.SetActive(false);
    }

    public void ActiveBigDeathNotification()
    {
        dNotificationBig.SetActive(true);
    }

    public void DeactiveBigDeathNotification()
    {
        dNotificationBig.SetActive(false);
    }

    public void NumeroDeBajas(int cantidad)
    {
        cantidadTxt.text = cantidad + " warriors died because of the fog";
    }
}
