using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoSupManager : MonoBehaviour
{
    [Header("WarriorStuff")]
    [SerializeField] private GameObject iconoCeatedW;
    [SerializeField] private GameObject iconoInactiveW;
    [SerializeField] private GameObject bttnCloseW;
    [SerializeField] private GameObject infoWSup;
    [SerializeField] private Animator infoWSupAnim;
    [SerializeField] private TextMeshProUGUI warriorCreatedTxt;
    [SerializeField] private TextMeshProUGUI warriorInactiveTxt;

    [Header("BuilderStuff")]
    [SerializeField] private GameObject iconoCeatedB;
    [SerializeField] private GameObject iconoInactiveB;
    [SerializeField] private GameObject bttnCloseB;
    [SerializeField] private GameObject infoBSup;
    [SerializeField] private Animator infoBSupAnim;
    [SerializeField] private TextMeshProUGUI builderCreatedTxt;
    [SerializeField] private TextMeshProUGUI builderInactiveTxt;

    private void Start()
    {
        infoBSupAnim = infoBSup.GetComponent<Animator>();
        infoWSupAnim = infoWSup.GetComponent<Animator>();
    }

    private void Update()
    {
        ActualizarTextoBuilder();
        ActualizarTextoWarrior();
    }

    public void OpenBuilderSupBttn()
    {
        bttnCloseB.SetActive(true);
        infoBSupAnim.SetBool("BuilderOpen", true);

        StartCoroutine(BuilderIconosExtra());
    }

    public void CloseBuilderSupBttn()
    {
        bttnCloseB.SetActive(false);
        infoBSupAnim.SetBool("BuilderOpen", false);

        iconoCeatedB.SetActive(false);
        iconoInactiveB.SetActive(false);
    }

    public void OpenWarriorSupBttn()
    {
        bttnCloseW.SetActive(true);
        infoWSupAnim.SetBool("InfoOpenW", true);

        StartCoroutine(WarriorIconosExtra());
    }

    public void CloseWarriorSupBttn()
    {
        bttnCloseW.SetActive(false);
        infoWSupAnim.SetBool("InfoOpenW", false);

        iconoCeatedW.SetActive(false);
        iconoInactiveW.SetActive(false);
    }

    IEnumerator BuilderIconosExtra()
    {
        yield return new WaitForSeconds(.3f);
        iconoCeatedB.SetActive(true);
        iconoInactiveB.SetActive(true);
    }

    IEnumerator WarriorIconosExtra()
    {
        yield return new WaitForSeconds(.3f);
        iconoCeatedW.SetActive(true);
        iconoInactiveW.SetActive(true);
    }

    private void ActualizarTextoBuilder()
    {
        builderCreatedTxt.text = StaticVariables.cantidadBuildersTotales + "/5";
        builderInactiveTxt.text = "" + StaticVariables.cantidadBuildersDisponibles;
    }

    private void ActualizarTextoWarrior()
    {
        warriorCreatedTxt.text = StaticVariables.cantidadAldeanosTotales + "/10";
        warriorInactiveTxt.text = "" + StaticVariables.cantidadAldeanosDisponibles;
    }
}
