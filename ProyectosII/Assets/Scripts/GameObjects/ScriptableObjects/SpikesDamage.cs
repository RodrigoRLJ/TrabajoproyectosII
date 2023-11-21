using UnityEngine;

namespace GameObjects.ScreiptableObjects
{
    [CreateAssetMenu(fileName = "Spikes Damage",
        menuName = "Scriptable Objects/Items Stats/Spikes Damage")]
    public class SpikesDamage : ScriptableObject
    {
        //Daño que recibe el jugador al tocar los pinchos
        //Make a public getter for this value
        [SerializeField] private int playerDamage;

        public int GetPlayerDamage()
        {
            return this.playerDamage;
        }
    }
}