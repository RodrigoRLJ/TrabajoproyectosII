using UnityEngine;
using UnityEngine.Tilemaps;

namespace Entities.Player
{
    public class PlayerFeetController : MonoBehaviour
    {
        public bool isOnGround;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Terreno"))
            {
                EventSystem.PlayerFell();
                this.isOnGround = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Terreno"))
            {
                EventSystem.PlayerFell();
                this.isOnGround = false;
            }
        }
    }
}