using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "PlayerGeneralStats", menuName = "Scriptable Objects/Player Stats/General Stats")]
    public class PlayerStats : ScriptableObject
    {
        //Salud inicial del jugador
        [SerializeField] public float playerInitialHealth;

        //Cantidad de pociones iniciales del jugador
        [SerializeField] public int playerInitialPotions;

        [SerializeField] public PlayerLateralMovement playerLateralMovementStats;
        [SerializeField] public PlayerVerticalMovement playerVerticalMovementStats;
    }
}