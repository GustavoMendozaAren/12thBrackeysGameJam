using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TorretsStats : MonoBehaviour
{
    [SerializeField] private GameObject panelEstadisticas;
    [SerializeField] private GameObject rangoSprite;

    [Header("TEXTOS")]
    [SerializeField] private TextMeshProUGUI cantidadPersonasTxt;
    [SerializeField] private TextMeshProUGUI damageTxt;
    [SerializeField] private TextMeshProUGUI rangeTxt;

    private int AldeanosEnTorre = 0;
    private int damage = 0;
    private int range = 1;

    private bool estaEnRangoDeFaro = false;

    void OnMouseDown()
    {
        panelEstadisticas.SetActive(!panelEstadisticas.activeSelf);
        rangoSprite.SetActive(!rangoSprite.activeSelf);
    }

    private void OnMouseEnter()
    {
        panelEstadisticas.SetActive(true);
        rangoSprite.SetActive(true);
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
            ActualizarCantidadPersonas();

            if(AldeanosEnTorre > 1)
            {
                range = 2;
                rangeTxt.text = range + "";
                rangoSprite.transform.localScale = new Vector3(0.48f, 0.48f, 0.48f);
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
        }
    }

    void ActualizarCantidadPersonas()
    {
        cantidadPersonasTxt.text = AldeanosEnTorre + "/2";
        damageTxt.text = damage + "";

        
        TextMeshProUGUI spareAldeanosTxt = GameObject.Find("AldeanosDisponibles_Txt").GetComponent<TextMeshProUGUI>();
        spareAldeanosTxt.text = "SPARE: " + StaticVariables.cantidadAldeanosDisponibles;
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

        TextMeshProUGUI aldeanosTotalesTxt = GameObject.Find("Aldeanos_Txt").GetComponent<TextMeshProUGUI>();
        aldeanosTotalesTxt.text = "ALDEANOS: " + StaticVariables.cantidadAldeanosTotales;
    }
}