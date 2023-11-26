using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class PlataformaUnSoloUso : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private int stableTime;
    [SerializeField] private bool destroyOnFall;
    [SerializeField] private GameObject platform;
    private bool falling;

    void Start()
    {
        this._rigidbody2D = this.platform.GetComponent<Rigidbody2D>();
    }

    /**
     * Acción que pasa cuando algo toca los pinchos
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Si tiene el tag de jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha tocado la plataforma");
            StartCoroutine(PlataformaCae());
        }

        if (other.CompareTag("Terreno") || other.gameObject.layer == this.gameObject.layer)
        {
            try
            {
                other.GetComponent<PlataformaUnSoloUso>().Dispose();
            }
            catch (Exception e)
            {
            }

            this.Dispose();
        }
    }

    private IEnumerator PlataformaCae()
    {
        yield return new WaitForSeconds(this.stableTime);
        this._rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        this.falling = true;
    }

    public void Dispose()
    {
        Debug.Log("La plataforma se ha destruido");
        if (this.falling && this.destroyOnFall)
        {
            Destroy(this.platform);
        }
    }
}