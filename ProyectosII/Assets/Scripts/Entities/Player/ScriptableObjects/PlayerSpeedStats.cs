using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "PlayerSpeedStats", menuName = "Scriptable Objects/Player Stats/Player Speed Stats")]
    public class PlayerSpeedStats : ScriptableObject
    {
        //The amount the player can accelerate every second
        [SerializeField] public int playerAcceleration;

        //The player max speed
        [SerializeField] public int playerMaxSpeed;

        //How fast the player losses speed when not moving
        [SerializeField] public int playerDeceleration;

        //The extra speed for changing the moving direction
        [SerializeField] public float playerTurnExtraForce;

        //Velocidad máxima del jugador en caída
        [SerializeField] public float playerMaxFallSpeed;

        //Boost de velocidad en la parte más alta del salto
        [SerializeField] public float playerSpeedBoostOnJumpApex;

        //Cuanto dura el boost de velocidad al saltar muy alto
        [SerializeField] public float playerSpeedBoostOnJumpApexDuration;
    }
}