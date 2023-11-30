using System;
using System.Collections;
using GameObjects;
using UnityEngine;

public class PlataformaUnSoloUso : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    private PlatformData _platformData;
    private Rigidbody2D _rigidbody2D;
    private bool _falling;


    void Start()
    {
        this._rigidbody2D = this.platform.GetComponent<Rigidbody2D>();
        this._platformData = this.platform.GetComponent<PlatformData>();
    }


    /**
     * Acción que pasa cuando algo toca los pinchos
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Si tiene el tag de jugador
        if (other.CompareTag("Player"))
        {
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

    /**
     * Resetea la posición del la plataforma
     */
    private void _resetPlatform()
    {
        Vector3 vector3 = new Vector3(this._platformData.GetStartX(), this._platformData.GetStartY(), 0);
        this.platform.transform.position = vector3;
        this.platform.transform.rotation = new Quaternion(0, 0, 0, 0);


        this._falling = false;
        this._rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    /*
     * Función que hace que la plataforma caiga.
     */

    private IEnumerator PlataformaCae()
    {
        yield return new WaitForSeconds(this._platformData.GetStableTime());
        this._rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        this._falling = true;
    }

    /**
     * Función cuando se quiere quitar una plataforma
     */
    public void Dispose()
    {
        if (this._falling && this._platformData.GetDestroyOnFall())
        {
            if (this._platformData.GetResetPlatform().Equals(false))
            {
                Destroy(this.platform);
            }
            else
            {
                this.Deactivate();
            }
        }
    }

    /**
     * Función para desactivar la plataforma.
     */
    private void Deactivate()
    {
        StartCoroutine(waitToReset());
    }

    IEnumerator waitToReset()
    {
        this.platform.gameObject.SetActive(false);
        this.Activate();
        yield return null;
    }

    private void Activate()
    {
        this.platform.gameObject.SetActive(true);
        this._resetPlatform();
    }
}