using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "PlayerVerticalMovement",
        menuName = "Scriptable Objects/Player Stats/Player Vertical Movement")]
    public class PlayerVerticalMovement : ScriptableObject
    {
        //Cantidad de saltos
        [SerializeField] public int jumps;

        //Fuerza mínima del salto
        [SerializeField] public float minJumpForce;

        //Fuerza maxima del salto
        [SerializeField] public float maxJumpForce;

        //Como de rápido se carga el salto
        [SerializeField] public float jumpChargeSpeed;

        //Velocidad máxima del jugador en caída
        [SerializeField] public float playerMaxFallSpeed;

        #region Not used

        /*//Cuanto tiempo como máximo puede estar saltando el jugador (si esta saltando menos tiempo asciende menos)
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

        //Boost de velocidad en la parte más alta del salto
        [SerializeField] public float playerSpeedBoostOnJumpApex;

        //Cuanto dura el boost de velocidad al saltar muy alto
        [SerializeField] public float playerSpeedBoostOnJumpApexDuration;*/

        #endregion
    }
}