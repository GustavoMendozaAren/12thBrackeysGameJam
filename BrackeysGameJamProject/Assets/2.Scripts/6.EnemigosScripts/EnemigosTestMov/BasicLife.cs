using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicLife : MonoBehaviour
{
    [SerializeField] private float vidaMaxima = 10f;
    private float vidaActual;
    [SerializeField] private Image barraDeVida;

    private Animator animator;

    private void Start()
    {
        vidaActual = 5f; // Inicia con la vida máxima
        ActualizarBarraDeVida();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealCollider"))
        {
            AumentarBasicVida();
        }
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

    public void AumentarBasicVida()
    {
        vidaActual += 2.5f;
        ActualizarBarraDeVida();
        if (vidaActual >= 10)
        {
            vidaActual = 10;
        }
    }

    private void Muerte()
    {
        animator.SetBool("IsDeath", true);
    }

    private void ActualizarBarraDeVida()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
    }

    private void DeactivateEnemy()
    {
        gameObject.SetActive(false);
    }
}
