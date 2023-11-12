using System.Collections;
using System.Collections.Generic;
using Entities.Player;
using UnityEngine;

public class HealthAlteringController : MonoBehaviour
{
    [SerializeField] private float healthAlteration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().PlayerChangeHealth(healthAlteration);
            Destroy(gameObject);
        }
    }
}