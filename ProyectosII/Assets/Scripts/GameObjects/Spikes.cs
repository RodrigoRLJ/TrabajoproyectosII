using Entities.Player;
using GameObjects.ScreiptableObjects;
using UnityEngine;

namespace GameObjects
{
    public class Spikes : MonoBehaviour
    {
        /**
         * Scriptable Object que guarda el daño que recibe el jugador al tocar los pinchos
         */
        [SerializeField] private SpikesDamage spikesDamage;

        /**
         * Objeto en cuya posición respawneará el jugador
         */
        [SerializeField] private GameObject respawnPoint;

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
                if (respawnPoint != null)
                {
                    //Y muévelo
                    other.GetComponent<PlayerController>().RelocatePlayer(respawnPoint.transform);   
                }
            }
        }
    }
}