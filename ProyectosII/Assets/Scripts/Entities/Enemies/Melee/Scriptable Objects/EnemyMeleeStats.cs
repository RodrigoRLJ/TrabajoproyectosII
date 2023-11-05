using UnityEngine;

namespace Entities.EnemyMelee
{
    [CreateAssetMenu(fileName = "EnemyMeleeStats",
        menuName = "Scriptable Objects/Enemy Stats/Enemy Melee Stats")]
    public class EnemyMeleeStats : ScriptableObject
    {
        //Distancia a la que atacará al jugador
        [SerializeField] public float distanceToPlayer;

        //velocidad que tendra al patrullar
        [SerializeField] public float patrolSpeed;

        //velocidad que tendra al atacar al jugador
        [SerializeField] public int attackSpeed;

        //vida del monstruo
        [SerializeField] public float health;

        
    }
}