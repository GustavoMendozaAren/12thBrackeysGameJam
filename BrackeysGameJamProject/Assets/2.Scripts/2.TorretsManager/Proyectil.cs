using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float dano = 0.2f; // Daño que hace este proyectil

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBasic"))
        {
            dano = 2.5f;
            EnemyLife vidaEnemigo = other.GetComponent<EnemyLife>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.ReducirVida(dano); // Aplica daño al enemigo
            }
            Destroy(gameObject); // Destruye el proyectil después de impactar
        }
        if (other.CompareTag("EnemyHealer"))
        {
            dano = 1f;
            EnemyLife vidaEnemigo = other.GetComponent<EnemyLife>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.ReducirVida(dano); // Aplica daño al enemigo
            }
            Destroy(gameObject); // Destruye el proyectil después de impactar
        }
        if (other.CompareTag("EnemyTank"))
        {
            dano = 0.5f;
            EnemyLife vidaEnemigo = other.GetComponent<EnemyLife>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.ReducirVida(dano); // Aplica daño al enemigo
            }
            Destroy(gameObject); // Destruye el proyectil después de impactar
        }
    }
}
