using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionManzana : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Player")){
            Debug.Log("Colisi�n");
        }
    }
}
