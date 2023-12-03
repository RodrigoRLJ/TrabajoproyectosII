using System;
using Entities.Player;
using GameObjects.ScreiptableObjects;
using UnityEngine;

namespace GameObjects
{
    public class SpikesBalls : MonoBehaviour
    {
        /**
         * Scriptable Object que guarda el daño que recibe el jugador al tocar los pinchos
         */
        [SerializeField] private SpikesDamage spikesDamage;

        private const float MAX_LIFE_TIME = 20f;
        private float lifeTime;

        public void Start()
        {
            this.lifeTime = 0;
        }

        /**
         * Acción que pasa cuando algo toca los pinchos
         */
        private void OnTriggerStay2D(Collider2D other)
        {
            //Si tiene el tag de jugador
            if (other.CompareTag("Player"))
            {
                //Cambia su salud
                other.GetComponent<PlayerController>().PlayerChangeHealth(-(this.spikesDamage.GetPlayerDamage()));
                Destroy(this.gameObject);
            } else if (other.CompareTag("DestroyBall"))
            {
                Destroy(this.gameObject);
            }
        }

        public void LateUpdate()
        {
            this.lifeTime += Time.deltaTime;
            if (this.lifeTime > MAX_LIFE_TIME)
            {
                Destroy(this.gameObject);
                
            }
        }
    }
}