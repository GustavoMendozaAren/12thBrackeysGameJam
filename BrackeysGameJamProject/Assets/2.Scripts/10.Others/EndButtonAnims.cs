using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtonAnims : MonoBehaviour
{
    [Header("OBJECTS")]
    [SerializeField] private GameObject rotObj;
    [SerializeField] private GameObject lunaObj;
    [SerializeField] private GameObject solObj;

    [Header("ANIMATORS")]
    [SerializeField] private Animator rotAnim;
    [SerializeField] private Animator lunaAnim;
    [SerializeField] private Animator solAnim;

    [Header("OTHER OBJECTS")]
    [SerializeField] private GameObject textEndDay;
    [SerializeField] private GameObject textEndNight;

    private void Start()
    {
        rotAnim = rotObj.GetComponent<Animator>();
        lunaAnim = lunaObj.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            LunaExitMethod();
        }
        if (Input.GetKey(KeyCode.U))
        {
            LunaInMethod();
        }
    }

    public void LunaExitMethod()
    {
        rotAnim.SetBool("LunaRot", true);
        lunaAnim.SetBool("LunaExit", true);
        solAnim.SetBool("SolExit", false);
        textEndDay.SetActive(false);
        textEndNight.SetActive(true);
    }

    public void LunaInMethod()
    {
        rotAnim.SetBool("LunaRot", false);
        lunaAnim.SetBool("LunaExit", false);
        solAnim.SetBool("SolExit", true);
        textEndDay.SetActive(true);
        textEndNight.SetActive(false);
    }
}
