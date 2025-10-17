using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Parámetros para el zoom.
    public float zoomSpeed = 5f;   // Velocidad del zoom.
    public float minZoom = 2f;     // Zoom mínimo.
    public float maxZoom = 10f;    // Zoom máximo.

    // Parámetros para el desplazamiento (Pan).
    public float panSpeed = 20f;   // Velocidad de desplazamiento.

    // Límites del área en la que puede moverse la cámara.
    public Vector2 minLimit = new Vector2(-10f, -10f);  // Límite negativo.
    public Vector2 maxLimit = new Vector2(10f, 10f);    // Límite positivo.

    private Camera cam;

    private Vector3 dragOrigin;

    private void Start()
    {
        // Obtener el componente de la cámara.
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        // Llamar a las funciones de zoom y desplazamiento en cada frame.
        ZoomCamera();
        PanCamera();
    }

    // Función que controla el zoom de la cámara.
    private void ZoomCamera()
    {
        // Obtener el valor de la rueda del mouse (positiva para adelante, negativa para atrás).
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Modificar el tamaño de la cámara en función de la entrada del mouse y la velocidad de zoom.
        cam.orthographicSize -= scrollInput * zoomSpeed;

        // Limitar el tamaño de la cámara dentro de los rangos establecidos.
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);

        BordesCamara();
    }

    // Función que controla el desplazamiento de la cámara con el botón derecho del mouse.
    private void PanCamera()
    {
        // Si se presiona el botón derecho del ratón.
        if (Input.GetMouseButtonDown(1))
        {
            // Guardar el punto inicial donde se hace clic.
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        // Si se mantiene presionado el botón derecho del ratón.
        if (Input.GetMouseButton(1))
        {
            // Calcular la diferencia entre la posición actual del mouse y el punto de origen.
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            // Mover la cámara en la dirección inversa a la diferencia calculada.
            transform.position += difference;

            BordesCamara();
        }

    }

    private void BordesCamara()
    {
        // Calcular los bordes visibles de la cámara.
        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        // Limitar la posición de la cámara de manera que los bordes no superen los límites.
        float clampedX = Mathf.Clamp(transform.position.x, minLimit.x + camWidth, maxLimit.x - camWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minLimit.y + camHeight, maxLimit.y - camHeight);

        // Actualizar la posición de la cámara.
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
