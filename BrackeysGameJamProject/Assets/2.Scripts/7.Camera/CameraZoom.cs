using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Par�metros para el zoom.
    public float zoomSpeed = 5f;   // Velocidad del zoom.
    public float minZoom = 2f;     // Zoom m�nimo.
    public float maxZoom = 10f;    // Zoom m�ximo.

    // Par�metros para el desplazamiento (Pan).
    public float panSpeed = 20f;   // Velocidad de desplazamiento.

    // L�mites del �rea en la que puede moverse la c�mara.
    public Vector2 minLimit = new Vector2(-10f, -10f);  // L�mite negativo.
    public Vector2 maxLimit = new Vector2(10f, 10f);    // L�mite positivo.

    private Camera cam;

    private Vector3 dragOrigin;

    private void Start()
    {
        // Obtener el componente de la c�mara.
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        // Llamar a las funciones de zoom y desplazamiento en cada frame.
        ZoomCamera();
        PanCamera();
    }

    // Funci�n que controla el zoom de la c�mara.
    private void ZoomCamera()
    {
        // Obtener el valor de la rueda del mouse (positiva para adelante, negativa para atr�s).
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Modificar el tama�o de la c�mara en funci�n de la entrada del mouse y la velocidad de zoom.
        cam.orthographicSize -= scrollInput * zoomSpeed;

        // Limitar el tama�o de la c�mara dentro de los rangos establecidos.
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);

        BordesCamara();
    }

    // Funci�n que controla el desplazamiento de la c�mara con el bot�n derecho del mouse.
    private void PanCamera()
    {
        // Si se presiona el bot�n derecho del rat�n.
        if (Input.GetMouseButtonDown(1))
        {
            // Guardar el punto inicial donde se hace clic.
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        // Si se mantiene presionado el bot�n derecho del rat�n.
        if (Input.GetMouseButton(1))
        {
            // Calcular la diferencia entre la posici�n actual del mouse y el punto de origen.
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            // Mover la c�mara en la direcci�n inversa a la diferencia calculada.
            transform.position += difference;

            BordesCamara();
        }

    }

    private void BordesCamara()
    {
        // Calcular los bordes visibles de la c�mara.
        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        // Limitar la posici�n de la c�mara de manera que los bordes no superen los l�mites.
        float clampedX = Mathf.Clamp(transform.position.x, minLimit.x + camWidth, maxLimit.x - camWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minLimit.y + camHeight, maxLimit.y - camHeight);

        // Actualizar la posici�n de la c�mara.
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
