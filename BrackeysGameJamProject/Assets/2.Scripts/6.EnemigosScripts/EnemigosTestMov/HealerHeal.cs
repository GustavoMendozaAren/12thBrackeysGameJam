using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealerHeal : MonoBehaviour
{   
    [SerializeField] private float vidaMaxima = 10f;
    [SerializeField] private Image barraDeVida;
    [SerializeField] private GameObject boxCollider;
    [SerializeField] private BoxCollider2D collider;

    private float vidaActual;

    private Animator animator;

    [HideInInspector] public bool RecibeDanioHealer = true;

    private void Start()
    {
        vidaActual = vidaMaxima; // Inicia con la vida máxima
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShieldCollider"))
        {
            RecibeDanioHealer = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ShieldCollider"))
        {
            RecibeDanioHealer = true;
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
            collider.enabled = false;
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
