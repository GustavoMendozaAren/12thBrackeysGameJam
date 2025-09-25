using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCloseBtn : MonoBehaviour
{
    [SerializeField] private GameObject closeTutBtn2;

    private void ActivateCloseTutBtn()
    {
        closeTutBtn2.SetActive(true);
    }
}
