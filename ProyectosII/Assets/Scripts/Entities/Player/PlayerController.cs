using UnityEngine;

namespace Entities.Player
{
    public class PlayerController : MonoBehaviour
    {
        private float _playerCurrentHealth;
        private int _playerCurrentPotions;

        #region Atribute declaration

        [SerializeField] private PlayerStats playerStats;
        private Animator _animator;
        private Rigidbody2D _rigidBody2D;
        private SpriteRenderer _spriteRenderer;
        private PlayerMovement _playerMovement;

        #endregion

        #region Object initialization and destruction

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
            this._resetPlayerStats();
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

        private void _resetPlayerStats()
        {
            this._playerCurrentHealth = this.playerStats.playerInitialHealth;
            this._playerCurrentPotions = this.playerStats.playerInitialPotions;
            this.PlayerChangeHealth(0f);
        }

        #endregion

        // Update is called once per frame
        private void Update()
        {
            this._playerMovement.UpdateActions();
        }

        public void PlayerChangeHealth(float healthAmount)
        {
            this._playerCurrentHealth += healthAmount;
            if (this._playerCurrentHealth > this.playerStats.playerInitialHealth)
            {
                this._playerCurrentHealth = this.playerStats.playerInitialHealth;
            }

            EventSystem.PlayerNewHealth(this.playerStats.playerInitialHealth, this._playerCurrentHealth);
            Debug.Log(this._playerCurrentHealth);
        }
    }
}