using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "PlayerGeneralStats", menuName = "Scriptable Objects/Player Stats/General Stats")]
    public class PlayerStats : ScriptableObject
    {
        //Salud inicial del jugador
        [SerializeField] public int playerInitialHealth;

        private int _playerCurrentHealth;

        //Cantidad de pociones iniciales del jugador
        [SerializeField] public int playerInitialPotions;
        private int _playerCurrentPotions;

        [SerializeField] public PlayerSpeedStats playerSpeedStats;
        [SerializeField] public PlayerControlStats playerControlStats;


        //Cantidad de vida que cura cada poción
        //[SerializeField] public int playerHealthPerPotion;

        public void ResetPlayerHealth()
        {
            this._playerCurrentHealth = this.playerInitialHealth;
            this._playerCurrentPotions = this.playerInitialPotions;
        }
    }
}