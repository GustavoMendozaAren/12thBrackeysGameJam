using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int vidaMaxima = 2;       // Vida máxima del enemigo
    //[SerializeField] private int danoPorProyectil = 1; // Daño que recibe por cada proyectil
    private int vidaActual;

    private void Start()
    {
        vidaActual = vidaMaxima; // Inicia con la vida máxima
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
