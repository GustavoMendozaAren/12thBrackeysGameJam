using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FarosTower : MonoBehaviour
{
    [SerializeField] private Light2D towerFaroLight;

    public void ActualizarFarosLight()
    {
        if (towerFaroLight != null)
        {
            towerFaroLight.pointLightOuterRadius -= 1f;  // Cambia el radio externo a lo que necesites
        }
        else
        {
            Debug.LogWarning("Light2D component not assigned to the FarosTower script.");
        }
    }
}
