using UnityEngine;

namespace Entities.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Atribute declaration

        [SerializeField] private PlayerStats playerStats;
        private Animator _animator;
        private Rigidbody2D _rigidBody2D;
        private SpriteRenderer _spriteRenderer;
        private PlayerMovement _playerMovement;

        #endregion

        // Start is called before the first frame update
        private void Start()
        {
            this._getChildComponents();

            this._playerMovement = new PlayerMovement(
                rigidBody2D: this._rigidBody2D,
                animator: this._animator,
                spriteRenderer: this._spriteRenderer,
                playerSpeedStats: this.playerStats.playerSpeedStats,
                playerControlStats: this.playerStats.playerControlStats);

            this._playerMovement.SubscribeToEvents();
        }

        private void _getChildComponents()
        {
            this._rigidBody2D = GetComponent<Rigidbody2D>();
            this._animator = GetComponent<Animator>();
            this._spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void OnDestroy()
        {
            this._playerMovement.UnsubscribeFromEvents();
        }

        // Update is called once per frame
        private void Update()
        {
            this._playerMovement.UpdateActions();
        }
    }
}