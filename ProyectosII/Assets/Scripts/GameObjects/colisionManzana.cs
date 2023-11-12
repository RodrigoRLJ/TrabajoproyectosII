using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.Player;

public class colisionManzana : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //acesso a componente PlayerController y su metodo PlayerChangeHealy 
            other.GetComponent<PlayerController>().PlayerChangeHealth(+50);
            Destroy(gameObject);
        }
    }
}
