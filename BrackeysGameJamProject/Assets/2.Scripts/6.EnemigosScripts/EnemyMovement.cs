using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private float speed = 3f;

    public void SetWaypoints(Transform[] waypoints)
    {
        this.waypoints = waypoints;
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        // Moverse hacia el siguiente punto
        Transform targetWaypoint = waypoints[currentWaypointIndex];
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
}
