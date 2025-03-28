using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackTurret : MonoBehaviour
{
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private Transform puntoDisparo;
    private float velocidadProyectil = 10f;
    private float rateOfFire = 1f;

    private Transform objetivo;
    private float tiempoProximoDisparo = 0f;

    private List<Transform> enemigosEnRango = new List<Transform>();

    [HideInInspector] public bool canAtack = false;
    [HideInInspector] public bool maxAtack = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBasic") || other.CompareTag("EnemyTank") || other.CompareTag("EnemyHealer"))
        {
            enemigosEnRango.Add(other.transform);

            // Si no hay objetivo actual, selecciona el primero
            if (objetivo == null)
            {
                objetivo = other.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBasic") || other.CompareTag("EnemyTank") || other.CompareTag("EnemyHealer"))
        {
            enemigosEnRango.Remove(other.transform);

            // Si el enemigo que sale es el objetivo actual
            if (other.transform == objetivo)
            {
                // Cambia el objetivo al primer enemigo en la lista o null si está vacía
                objetivo = enemigosEnRango.Count > 0 ? enemigosEnRango[0] : null;
            }
        }
    }

    private void Update()
    {
        velocidadProyectil = StaticVariables.proyectileSpeed;
        rateOfFire = StaticVariables.rateOfFire;

        // Si hay un objetivo y es momento de disparar
        if (objetivo != null && Time.time >= tiempoProximoDisparo)
        {
            Disparar();
            tiempoProximoDisparo = Time.time + rateOfFire;
        }
    }

    private void Disparar()
    {
        if (canAtack)
        {
            Vector2 direccion = (objetivo.position - puntoDisparo.position).normalized;
            GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, Quaternion.identity);

            Proyectil proyectilScript = proyectil.GetComponent<Proyectil>();
            proyectilScript.dano = CalcularDanoTorreta();

            Rigidbody2D rbProyectil = proyectil.GetComponent<Rigidbody2D>();
            rbProyectil.velocity = direccion * velocidadProyectil;

            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
            proyectil.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo - 90));
        }
    }

    private int CalcularDanoTorreta()
    {
        return maxAtack ? 2 : 1;
    }

}
