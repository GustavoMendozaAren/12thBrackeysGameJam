using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackTurret : MonoBehaviour
{
    [SerializeField] private GameObject proyectilPrefab;      // Prefab del proyectil
    [SerializeField] private Transform puntoDisparo;          // Punto desde donde se dispara el proyectil
    private float velocidadProyectil = 10f;  // Velocidad del proyectil
    private float rateOfFire = 1f;           // Tasa de disparo (en segundos)

    private Transform objetivo;             // Almacena la posición del enemigo detectado
    private float tiempoProximoDisparo = 0f;

    [HideInInspector] public bool canAtack = false;
    [HideInInspector] public bool maxAtack = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto detectado es un enemigo
        if (other.CompareTag("EnemyBasic") || other.CompareTag("EnemyTank"))
        {
            objetivo = other.transform; // Almacena el enemigo como objetivo
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Cuando el enemigo sale del rango, se elimina como objetivo
        if (other.CompareTag("EnemyBasic") || other.CompareTag("EnemyTank"))
        {
            objetivo = null;
        }
    }

    private void Update()
    {
        velocidadProyectil = StaticVariables.proyectileSpeed;
        rateOfFire = StaticVariables.rateOfFire;

        // Si hay un enemigo en rango y el tiempo de disparo ha pasado
        if (objetivo != null && Time.time >= tiempoProximoDisparo)
        {
            Disparar();
            tiempoProximoDisparo = Time.time + rateOfFire; // Define el próximo tiempo de disparo
        }
    }

    /*
    private void Disparar()
    {
        if (canAtack)
        {
            // Calcula la dirección hacia el enemigo
            Vector2 direccion = (objetivo.position - puntoDisparo.position).normalized;

            // Crea el proyectil en el punto de disparo y lo direcciona hacia el enemigo
            GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, Quaternion.identity);
            Rigidbody2D rbProyectil = proyectil.GetComponent<Rigidbody2D>();

            // Aplica velocidad al proyectil en la dirección calculada
            rbProyectil.velocity = direccion * velocidadProyectil;
        }
    }*/

    private void Disparar()
    {
        if (canAtack)
        {
            Vector2 direccion = (objetivo.position - puntoDisparo.position).normalized;
            GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, Quaternion.identity);

            Proyectil proyectilScript = proyectil.GetComponent<Proyectil>();
            proyectilScript.dano = CalcularDanoTorreta(); // Ajusta el daño según la torreta

            Rigidbody2D rbProyectil = proyectil.GetComponent<Rigidbody2D>();
            rbProyectil.velocity = direccion * velocidadProyectil;

            // Rotación del proyectil hacia el objetivo
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg; // Calcular el ángulo
            proyectil.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo - 90)); // Ajustar rotación restando 90 grados
        }
    }

    private int CalcularDanoTorreta()
    {
        if (maxAtack) 
        {
            return 2;
        }
        else
        {
            return 1;
        }
       
    }

}
