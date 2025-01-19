using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TorretsStats : MonoBehaviour
{
    [Header ("PANELES")]
    [SerializeField] private GameObject openedArcherInfoPanel;
    [SerializeField] private GameObject closedArcherInfoPanel;
    [SerializeField] private GameObject rangoSprite;
    [SerializeField] private CircleCollider2D rangoCollider;

    [Header("TEXTOS")]
    [SerializeField] private TextMeshProUGUI cantidadPersonasTxt;
    [SerializeField] private TextMeshProUGUI damageTxt;
    [SerializeField] private TextMeshProUGUI rangeTxt;

    private TextMeshProUGUI aldeanosTotalesTxt;

    private int AldeanosEnTorre = 0;
    private int damage = 0;
    private int range = 1;

    private bool estaEnRangoDeFaro = false;

    [SerializeField] private AtackTurret atack;

    private void Start()
    {
        aldeanosTotalesTxt = GameObject.Find("Aldeanos_Txt").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FaroTower"))
        {
            estaEnRangoDeFaro = true;
            Debug.Log("Arquero ha entrado en el rango de la torre de Faro");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FaroTower"))
        {
            estaEnRangoDeFaro = false;
            Debug.Log("Arquero ha salido del rango de la torre de Faro");
        }
    }

    public void AniadirAldeanoATorre()
    {
        if (AldeanosEnTorre < 2 && StaticVariables.cantidadAldeanosDisponibles > 0)
        {
            StaticVariables.cantidadAldeanosDisponibles--;
            AldeanosEnTorre++;
            damage += 10;
            rangoCollider.radius = 6.165f;
            ActualizarCantidadPersonas();

            if(AldeanosEnTorre > 1)
            {
                range = 2;
                rangeTxt.text = range + "";
                rangoSprite.transform.localScale = new Vector3(0.48f, 0.48f, 0.48f);
                rangoCollider.radius = 12.2f;
            }
        }
    }

    public void RemoverAldeanoDeTorre()
    {
        if (AldeanosEnTorre > 0)
        {
            StaticVariables.cantidadAldeanosDisponibles++;
            AldeanosEnTorre--;
            damage -= 10;
            ActualizarCantidadPersonas();
        }

        if (AldeanosEnTorre < 2)
        {
            range = 1;
            rangeTxt.text = range + "";
            rangoSprite.transform.localScale = new Vector3(0.24f, 0.24f, 0.24f);
            rangoCollider.radius = 6.165f;
        }
    }

    void ActualizarCantidadPersonas()
    {
        cantidadPersonasTxt.text = AldeanosEnTorre + "/2";
        damageTxt.text = damage + "";
        rangeTxt.text = range + "";


        TextMeshProUGUI spareAldeanosTxt = GameObject.Find("AldeanosDisponibles_Txt").GetComponent<TextMeshProUGUI>();
        spareAldeanosTxt.text = "" + StaticVariables.cantidadAldeanosDisponibles;

        ChecaSiPuedeAtacar();
    }

    public void ActualizarAldeanosMuertos()
    {
        if (!estaEnRangoDeFaro)
        {
            if (AldeanosEnTorre > 0)
            {
                if (AldeanosEnTorre == 1)
                {
                    ActualizarAldeanosTotalesYTorre(1);
                    ActualizarCantidadPersonas();
                }

                if (AldeanosEnTorre == 2)
                {
                    ActualizarAldeanosTotalesYTorre(2);
                    ActualizarCantidadPersonas();
                }
            }
        }
    }

    void ActualizarAldeanosTotalesYTorre(int number)
    {
        StaticVariables.cantidadAldeanosTotales -= number;

        AldeanosEnTorre -= number;
        damage -= (number * 10);
        range -= number;

        
        aldeanosTotalesTxt.text = "" + StaticVariables.cantidadAldeanosTotales;

        rangoSprite.transform.localScale = new Vector3(0.24f, 0.24f, 0.24f);
    }

    void ChecaSiPuedeAtacar()
    {
        if(AldeanosEnTorre > 0)
        {
            atack.canAtack = true;
        }else
        {
            atack.canAtack= false;
        }

        if (AldeanosEnTorre == 2) 
        {
            atack.maxAtack = true;
        }
        else
        {
            atack.maxAtack = false;
        }
    }

    public void InfoOpenArcherBttn()
    {
        openedArcherInfoPanel.SetActive(true);
        closedArcherInfoPanel.SetActive(false);
        rangoSprite.SetActive(true);
    }

    public void InfoCloseArcherBttn()
    {
        openedArcherInfoPanel.SetActive(false);
        closedArcherInfoPanel.SetActive(true);
        rangoSprite.SetActive(false);
    }
}
