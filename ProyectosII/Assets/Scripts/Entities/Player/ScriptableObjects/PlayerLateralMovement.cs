using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "PlayerLateralMovement",
        menuName = "Scriptable Objects/Player Stats/Player Lateral Movement")]
    public class PlayerLateralMovement : ScriptableObject
    {
        //The amount the player can accelerate every second
        [SerializeField] public float playerAcceleration;

        //The player max speed
        [SerializeField] public float playerMaxSpeed;

        //How fast the player losses speed when not moving
        [SerializeField] public float playerDeceleration;
    }
}