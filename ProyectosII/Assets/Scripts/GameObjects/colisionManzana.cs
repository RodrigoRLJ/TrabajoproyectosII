using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.Player;

public class colisionManzana : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().PlayerChangeHealth(+10);
        }

        Destroy(gameObject);
    }
}