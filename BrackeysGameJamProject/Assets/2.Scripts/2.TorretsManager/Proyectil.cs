using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int dano = 10; // Da�o que hace este proyectil

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyLife vidaEnemigo = other.GetComponent<EnemyLife>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.ReducirVida(dano); // Aplica da�o al enemigo
            }
            Destroy(gameObject); // Destruye el proyectil despu�s de impactar
        }
    }
}
