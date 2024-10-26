using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int vidaMaxima = 2;       // Vida m�xima del enemigo
    //[SerializeField] private int danoPorProyectil = 1; // Da�o que recibe por cada proyectil
    private int vidaActual;

    private void Start()
    {
        vidaActual = vidaMaxima; // Inicia con la vida m�xima
    }

    public void ReducirVida(int cantidadDeDano)
    {
        vidaActual -= cantidadDeDano;

        if (vidaActual <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Destroy(gameObject);
    }
}
