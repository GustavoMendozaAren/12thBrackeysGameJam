using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int dano = 10; // Daño que hace este proyectil

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyLife vidaEnemigo = other.GetComponent<EnemyLife>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.ReducirVida(dano); // Aplica daño al enemigo
            }
            Destroy(gameObject); // Destruye el proyectil después de impactar
        }
    }
}
