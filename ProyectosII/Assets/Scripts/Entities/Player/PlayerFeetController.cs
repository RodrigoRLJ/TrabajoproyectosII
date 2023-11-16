using UnityEngine;
using UnityEngine.Tilemaps;

namespace Entities.Player
{
    public class PlayerFeetController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Terreno"))
            {
                EventSystem.PlayerFell();
            }
        }
    }
}