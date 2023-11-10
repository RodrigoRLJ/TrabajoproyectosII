using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manzana : MonoBehaviour {

    private void OnCollisionEnter(Collision2D other) {
        if (other.collider.CompareTag("Player")) { 
            Debug.Log("Colisión");
        }
    }
    
}
