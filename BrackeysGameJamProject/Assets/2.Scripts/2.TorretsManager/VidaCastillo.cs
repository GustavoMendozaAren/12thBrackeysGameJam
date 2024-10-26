using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaCastillo : MonoBehaviour
{
    [SerializeField] private float vidaMaxima = 1f;       // Vida m�xima del castillo
    [SerializeField] private float danoPorEnemigo = .05f;    // Da�o que recibe por enemigo
    private float vidaActual;

    [SerializeField] private Image barraDeVida;          // Referencia a la imagen de la barra de vida

    [SerializeField] private GameObject defeatedPanel;

    private void Start()
    {
        vidaActual = vidaMaxima;       // Inicia con la vida m�xima
        ActualizarBarraDeVida();       // Actualiza la barra de vida en el inicio
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ReducirVida();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ReducirVida();
        }
    }

    private void ReducirVida()
    {
        vidaActual -= danoPorEnemigo;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);  // Limita la vida m�nima a 0
        ActualizarBarraDeVida();                              // Actualiza la barra de vida

        if (vidaActual <= 0)
        {
            GameOver();
        }
    }

    private void ActualizarBarraDeVida()
    {
        // Calcula el valor de llenado en funci�n de la vida actual
        barraDeVida.fillAmount = (float)vidaActual / vidaMaxima;
    }

    private void GameOver()
    {
        defeatedPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
