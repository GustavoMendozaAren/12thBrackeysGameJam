using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricada : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);  // Destruir la barricada si la salud llega a 0
        }
    }
}
