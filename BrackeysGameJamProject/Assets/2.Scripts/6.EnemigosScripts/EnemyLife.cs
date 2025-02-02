using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private float vidaMaxima = 1;       // Vida m�xima del enemigo
    //[SerializeField] private int danoPorProyectil = 1; // Da�o que recibe por cada proyectil
    private float vidaActual;
    [SerializeField] private Image barraDeVida;

    private Animator animator;

    private void Start()
    {
        vidaActual = vidaMaxima; // Inicia con la vida m�xima
        ActualizarBarraDeVida();
        animator = GetComponent<Animator>();
    }

    public void ReducirVida(float cantidadDeDano)
    {
        vidaActual -= cantidadDeDano;
        ActualizarBarraDeVida();

        if (vidaActual <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        animator.SetBool("IsDeath", true);
    }

    private void ActualizarBarraDeVida()
    {
        // Calcula el valor de llenado en funci�n de la vida actual
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
    }

    private void DeactivateEnemy()
    {
        gameObject.SetActive(false);
    }
}
