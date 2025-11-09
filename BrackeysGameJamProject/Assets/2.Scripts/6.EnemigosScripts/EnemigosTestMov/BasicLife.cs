using UnityEngine;
using UnityEngine.UI;

public class BasicLife : MonoBehaviour
{
    [SerializeField] private float vidaMaxima = 10f;
    [SerializeField] private Image barraDeVida;
    [SerializeField] private BoxCollider2D collider;

    private float vidaActual;
    
    private Animator animator;

    [HideInInspector] public bool RecibeDanioBasic = true;

    private void Start()
    {
        vidaActual = vidaMaxima; // Inicia con la vida máxima
        ActualizarBarraDeVida();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealCollider"))
        {
            AumentarBasicVida();
        }

        if (collision.CompareTag("ShieldCollider"))
        {
            RecibeDanioBasic = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ShieldCollider"))
        {
            RecibeDanioBasic = true;
        }
    }

    public void ReducirVida(float cantidadDeDano)
    {
        vidaActual -= cantidadDeDano;
        ActualizarBarraDeVida();

        if (vidaActual <= 0)
        {
            collider.enabled = false;
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
