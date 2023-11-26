using System;
using UnityEngine;

namespace GameObjects.ScreiptableObjects
{
    public class PlataformaMovil : MonoBehaviour
    {
        //Daño que recibe el jugador al tocar los pinchos
        //Make a public getter for this value
        [SerializeField] private GameObject[] paradas;

        [SerializeField] private int speed;

        /**
         * La parada en la que se encuentra la plataforma.
         */
        private int _paradaActual;

        public PlataformaMovil()
        {
            this._paradaActual = 0;
        }

        public void Update()
        {
            if (this.transform.position.Equals(this.paradas[this._paradaActual].transform.position))
            {
                this._findNewTarget();
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position,
                    this.paradas[this._paradaActual].transform.position, Time.deltaTime * this.speed);
            }
        }

        private void _findNewTarget()
        {
            do
            {
                this._paradaActual++;
                if (this._paradaActual == this.paradas.Length)
                {
                    this._paradaActual = 0;
                }
            } while (this.paradas[this._paradaActual] == null);
        }
    }
}