using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "PlayerControlStats",
        menuName = "Scriptable Objects/Player Stats/Player Control Stats")]
    public class PlayerControlStats : ScriptableObject
    {
        //Cuanto tiempo como máximo puede estar saltando el jugador (si esta saltando menos tiempo asciende menos)
        [SerializeField] public float playerMaxJumpTime;

        //Cuanto tiempo tiene el jugador para saltar desde la última ez que toco suelo
        [SerializeField] public float playerCoyoteTime;

        //Cuantos saltos seguidos puede hacer el jugador
        [SerializeField] public int playerJumpsAvailable;

        //Tiempo sin gravedad en la parte más alta del salto
        [SerializeField] public float playerAntigravityTime;

        //Permite cargar el siguiente salto antes de tocar el suelo
        [SerializeField] public bool jumpBuffer;

        //Permite alcanzar un borde si te quedas a poquito
        [SerializeField] public float playerEdgeDetectionDistance;
    }
}