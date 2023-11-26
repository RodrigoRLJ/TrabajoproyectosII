using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour{
   
    [SerializeField] private GameObject camara;

    private Vector2 offset;
    private Material material;
    private Rigidbody2D jugador;

  /*  private void Awake(){
        material = GetComponent<SpriteRenderer>().material;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }*/
    
    private void Update() {

        if (camara != null) { 
            this.transform.position = camara.transform.position;
        }

       //  offset = (jugador.velocity.x * 0.1f) * velocidadMovimiento * Time.deltaTime;
      //   material.mainTextureOffset += offset;

    }
}
