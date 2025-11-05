using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealerHeal : MonoBehaviour
{   
    [SerializeField] private float vidaMaxima = 10f;       // Vida máxima del enemigo
    //[SerializeField] private int danoPorProyectil = 1; // Daño que recibe por cada proyectil
    private float vidaActual;
    [SerializeField] private Image barraDeVida;
    [SerializeField] private GameObject boxCollider;

    private Animator animator;

    private BasicLife basicLife;
    private TankLife tankLife;

    private void Start()
    {
        vidaActual = 5f; // Inicia con la vida máxima
        ActualizarBarraDeVida();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Animations();
        }
    }

    private void Animations()
    {
        animator.SetTrigger("Healing");
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

    public void AumentarVida()
    {
        vidaActual += 2.5f;
        ActualizarBarraDeVida();
        if (vidaActual >= 10)
        {
            vidaActual = 10;
        }
    }

    public void HealLifeOnAnimation()
    {
        AumentarVida();
        StartCoroutine(ActivarCollider());
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

    IEnumerator ActivarCollider()
    {
        boxCollider.SetActive(true);
        yield return new WaitForSeconds(.5f);
        boxCollider.SetActive(false);

    }
}
