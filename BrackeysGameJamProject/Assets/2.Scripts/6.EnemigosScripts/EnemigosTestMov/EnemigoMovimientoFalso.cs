using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimientoFalso : MonoBehaviour
{
    private float startPointX; // Posici�n inicial en X (se establece al iniciar el juego)
    public float endPointX = 5f; // Posici�n final en X
    public float moveSpeed = 5f; // Velocidad de movimiento

    private bool movingToEnd = true; // Controla la direcci�n del movimiento

    private float targetX;
    private float newX;
    private Vector3 currentPosition;

    void Start()
    {
        startPointX = transform.position.x;
    }

    void Update()
    {
        // Determinar el destino actual
        targetX = movingToEnd ? endPointX : startPointX;

        // Obtener la posici�n actual del objeto
        currentPosition = transform.position;

        // Calcular la nueva posici�n en X
        newX = Mathf.MoveTowards(currentPosition.x, targetX, moveSpeed * Time.deltaTime);

        // Actualizar la posici�n del objeto
        transform.position = new Vector3(newX, currentPosition.y, currentPosition.z);

        // Verificar si lleg� al destino
        if (Mathf.Abs(currentPosition.x - targetX) < 0.1f)
        {
            movingToEnd = !movingToEnd; // Cambiar la direcci�n del movimiento
        }
    }
}
