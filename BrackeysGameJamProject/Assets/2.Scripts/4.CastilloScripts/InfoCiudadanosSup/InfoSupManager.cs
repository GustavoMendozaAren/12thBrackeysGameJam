using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSupManager : MonoBehaviour
{
    [Header("WarriorStuff")]
    [SerializeField] private GameObject iconoCeatedW;
    [SerializeField] private GameObject iconoInactiveW;
    [SerializeField] private GameObject bttnW;
    [SerializeField] private GameObject infoWSup;
    [SerializeField] private Animator infoWSupAnim;

    [Header("BuilderStuff")]
    [SerializeField] private GameObject iconoCeatedB;
    [SerializeField] private GameObject iconoInactiveB;
    [SerializeField] private GameObject bttnCloseB;
    [SerializeField] private GameObject infoBSup;
    [SerializeField] private Animator infoBSupAnim;

    private bool builderBttnActive = false;

    private void Start()
    {
        infoBSupAnim = infoBSup.GetComponent<Animator>();
    }

    public void OpenBuilderSupBttn()
    {
        bttnCloseB.SetActive(true);
        infoBSupAnim.SetBool("BuilderOpen", true);
        builderBttnActive = true;

        StartCoroutine(BuilderIconosExtra());
    }

    public void CloseBuilderSupBttn()
    {
        bttnCloseB.SetActive(false);
        infoBSupAnim.SetBool("BuilderOpen", false);
        builderBttnActive = false;

        iconoCeatedB.SetActive(false);
        iconoInactiveB.SetActive(false);
    }

    public void OpenWarriorSupBttn()
    {

    }

    public void CloseWarriorSupBttn()
    {

    }

    IEnumerator BuilderIconosExtra()
    {
        yield return new WaitForSeconds(.3f);
        iconoCeatedB.SetActive(true);
        iconoInactiveB.SetActive(true);
    }
}
