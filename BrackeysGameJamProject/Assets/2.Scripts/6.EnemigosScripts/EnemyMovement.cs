using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Waypoints Variables
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private float speed;
    private Transform targetWaypoint;
    [SerializeField] private int ID; // 1-Basic, 2-Healer, 3-Tank

    // Animations Variables
    private Animator animator;
    private BoxCollider2D boxCollider;

    [SerializeField] private GameObject[] vfx;

    private bool continuarMovimiento;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        continuarMovimiento = true;
    }

    public void SetWaypoints(Transform[] waypoints)
    {
        this.waypoints = waypoints;
    }

    void Update()
    {
        if(continuarMovimiento)
            SeguimientoDePuntos();

        VelocidadDeLaAnimacion();

        if (Input.GetKey(KeyCode.T))
        {
            Animations();
        }
    }

    private void Animations()
    {
        if (ID == 1)
            animator.SetTrigger("Attack");
        else if (ID == 2)
            animator.SetTrigger("Healing");
        else if (ID == 3)
            animator.SetTrigger("ShieldActive");

    }

    private void SeguimientoDePuntos()
    {
        speed = 0.3f * StaticVariables.enemiesSpeed;

        if (waypoints == null || waypoints.Length == 0) return;

        // Moverse hacia el siguiente punto
        targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Si ha llegado al punto actual, ir al siguiente
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;

            // Si llegó al último punto, destruir el enemigo o reiniciar su movimiento
            if (currentWaypointIndex >= waypoints.Length)
            {
                Destroy(gameObject);
            }
        }
    }

    private void VelocidadDeLaAnimacion()
    {
        animator.speed = StaticVariables.enemiesSpeed;
    }

    public void VfxYMovimientoHealer()
    {
        StartCoroutine(DesactivarVfx());
        continuarMovimiento = false;
    }

    public void VfxActive()
    {
        StartCoroutine(DesactivarVfx());    
    }

    public void VfxDeactive()
    {
        continuarMovimiento = true;
    }

    public void DetenerMovimiento()
    {
        continuarMovimiento = false;
        boxCollider.enabled = false;
    }

    IEnumerator DesactivarVfx()
    {
        foreach(GameObject effects in vfx)
        {
            effects.SetActive(true);
        }
        yield return new WaitForSeconds(2f);
        foreach (GameObject effects in vfx)
        {
            effects.SetActive(false);
        }
    }
}
