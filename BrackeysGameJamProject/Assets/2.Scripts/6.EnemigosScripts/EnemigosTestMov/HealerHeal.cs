using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealerHeal : MonoBehaviour
{   
    [SerializeField] private float vidaMaxima = 10f;
    [SerializeField] private Image barraDeVida;
    [SerializeField] private GameObject boxCollider;
    [SerializeField] private BoxCollider2D collider;

    private Animator animator;
    private float vidaActual;
    private int contador;

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
        if (collision.CompareTag("HealCollider") && StaticVariables.NivelDeDificultidad == 3)
        {
            AumentarVida();
        }

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
        AnimacionEspecial();

        vidaActual -= cantidadDeDano;
        ActualizarBarraDeVida();

        if (vidaActual <= 0)
        {
            collider.enabled = false;
            Muerte();
        }
    }

    private void AumentarVida()
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
        if (StaticVariables.NivelDeDificultidad == 2)
            AumentarVida();

        StartCoroutine(ActivarCollider());
    }

    private void AnimacionEspecial()
    {
        contador++;

        if ((contador >= 1 && contador < 2) || (contador >= 8 && contador < 9))
        {
            animator.SetTrigger("Healing");
        }
        else if (contador >= 14)
        {
            contador = 0;
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

    IEnumerator ActivarCollider()
    {
        boxCollider.SetActive(true);
        yield return new WaitForSeconds(.5f);
        boxCollider.SetActive(false);
    }
}
