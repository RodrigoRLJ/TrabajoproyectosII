using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manzana : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("Colisi�n");
        }
    }
}