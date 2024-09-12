using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10f;  // Da�o que hace el enemigo
    private bool isAttacking = false;
    private GameObject targetBarricade;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Barricade"))  // Verifica si el objeto es una barricada
        {
            targetBarricade = other.gameObject;
            isAttacking = true;
            StartCoroutine(AttackBarricade());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Barricade"))
        {
            isAttacking = false;
            StopCoroutine(AttackBarricade());
        }
    }

    IEnumerator AttackBarricade()
    {
        while (isAttacking)
        {
            // Aqu� llamas a la funci�n que le hace da�o a la barricada
            targetBarricade.GetComponent<Barricada>().TakeDamage(damageAmount);

            // Espera 2 segundos antes de volver a atacar
            yield return new WaitForSeconds(2f);
        }
    }
}
