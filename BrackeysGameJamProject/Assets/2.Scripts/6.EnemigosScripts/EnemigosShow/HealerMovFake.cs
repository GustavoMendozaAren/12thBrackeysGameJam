using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerMovFake : MonoBehaviour
{
    private float startPointX; // Posición inicial en X (se establece al iniciar el juego)
    public float endPointX = 5f; // Posición final en X
    public float moveSpeed = 5f; // Velocidad de movimiento

    private bool movingToEnd = true; // Controla la dirección del movimiento

    private float targetX;
    private float newX;
    private Vector3 currentPosition;

    private Animator animator;

    [SerializeField] private GameObject healVfx;
    [SerializeField] private GameObject healVfxFront;

    private bool contMov = true;

    void Start()
    {
        startPointX = transform.position.x;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (contMov)
        {
            SeMueve();
        }

        if (Input.GetKey(KeyCode.T))
        {
            Animations();
        }
    }

    private void SeMueve()
    {
        // Determinar el destino actual
        targetX = movingToEnd ? endPointX : startPointX;

        // Obtener la posición actual del objeto
        currentPosition = transform.position;

        // Calcular la nueva posición en X
        newX = Mathf.MoveTowards(currentPosition.x, targetX, moveSpeed * Time.deltaTime);

        // Actualizar la posición del objeto
        transform.position = new Vector3(newX, currentPosition.y, currentPosition.z);

        // Verificar si llegó al destino
        if (Mathf.Abs(currentPosition.x - targetX) < 0.1f)
        {
            movingToEnd = !movingToEnd; // Cambiar la dirección del movimiento
        }
    }

    private void Animations()
    {
        animator.SetTrigger("Healing");
        
    }

    IEnumerator DesactivarVfx()
    {
        healVfx.SetActive(true);
        healVfxFront.SetActive(true);
        yield return new WaitForSeconds(2f);
        healVfx.SetActive(false);
        healVfxFront.SetActive(false);
    }

    public void StopMovFunc()
    {
        contMov = false;
        StartCoroutine(DesactivarVfx());
    }

    public void ContinueMovFunc()
    {
        contMov = true;
    }
}
