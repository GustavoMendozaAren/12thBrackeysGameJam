using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimientoFalso : MonoBehaviour
{
    private float startPointX; // Posici�n inicial en X (se establece al iniciar el juego)
    public float endPointX = 5f; // Posici�n final en X
    public float moveSpeed = 5f; // Velocidad de movimiento

    private bool movingToEnd = true; // Controla la direcci�n del movimiento

    void Start()
    {
        // Establecer el punto inicial como la posici�n actual en X del objeto
        startPointX = transform.position.x;
    }

    void Update()
    {
        // Determinar el destino actual
        float targetX = movingToEnd ? endPointX : startPointX;

        // Obtener la posici�n actual del objeto
        Vector3 currentPosition = transform.position;

        // Calcular la nueva posici�n en X
        float newX = Mathf.MoveTowards(currentPosition.x, targetX, moveSpeed * Time.deltaTime);

        // Actualizar la posici�n del objeto
        transform.position = new Vector3(newX, currentPosition.y, currentPosition.z);

        // Verificar si lleg� al destino
        if (Mathf.Abs(currentPosition.x - targetX) < 0.1f)
        {
            movingToEnd = !movingToEnd; // Cambiar la direcci�n del movimiento
        }
    }
}
