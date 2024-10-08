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

        /*private Camera cam;

        [Header ("ZOOM CAMERA VARIABLES")]

        // Velocidad de zoom para ajustar el tama�o de la c�mara.
        public float zoomSpeed = 5f;

        // L�mites m�nimo y m�ximo para el zoom.
        public float minZoom = 2f;
        public float maxZoom = 10f;


        [Header("PAN CAMERA VARIABLES")]

        // Velocidad de movimiento de la c�mara.
        public float panSpeed = 20f;

        // L�mites del �rea en la que puede moverse la c�mara (los bordes del mundo).
        public Vector2 minLimit = new Vector2(-10f, -10f);  // L�mite negativo.
        public Vector2 maxLimit = new Vector2(10f, 10f);    // L�mite positivo.

        float camHeight;
        float camWidth;
        float moveX;
        float moveY;

        private void Start()
        {
            // Obtener el componente de la c�mara.
            cam = GetComponent<Camera>();
        }

        private void Update()
        {
            ZoomCamreaFunc();
            PanCameraFunc();
        }

        private void ZoomCamreaFunc()
        {
            // Obtener el valor de la rueda del mouse (positiva para adelante, negativa para atr�s).
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");

            // Modificar el tama�o de la c�mara en funci�n de la entrada del mouse y la velocidad de zoom.
            cam.orthographicSize -= scrollInput * zoomSpeed;

            // Limitar el tama�o de la c�mara dentro de los rangos establecidos.
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }

        private void PanCameraFunc()
        {
            // Si el bot�n derecho del mouse est� presionado.
            if (Input.GetMouseButton(1))
            {
                // Capturar el movimiento del mouse.
                moveX = -Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
                moveY = -Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;

                // Mover la c�mara.
                Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0f);

                // Limitar la posici�n de la c�mara dentro de los l�mites establecidos.
                newPosition.x = Mathf.Clamp(newPosition.x, minLimit.x, maxLimit.x);
                newPosition.y = Mathf.Clamp(newPosition.y, minLimit.y, maxLimit.y);

                // Actualizar la posici�n de la c�mara.
                transform.position = newPosition;
            }
        }

        private void CameraLimites()
        {
            // Calcular los bordes visibles de la c�mara.
            camHeight = cam.orthographicSize;
            camWidth = camHeight * cam.aspect;

            // Limitar la posici�n de la c�mara de manera que los bordes no superen los l�mites.
            //newPosition.x = Mathf.Clamp(newPosition.x, minLimit.x + camWidth, maxLimit.x - camWidth);
            //newPosition.y = Mathf.Clamp(newPosition.y, minLimit.y + camHeight, maxLimit.y - camHeight);
        }*/
    
}
