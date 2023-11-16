using UnityEngine;

namespace Entities.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Atribute declaration

        private float _playerCurrentHealth;
        private int _playerCurrentPotions;

        [SerializeField] private PlayerStats playerStats;
        private Animator _animator;
        private Rigidbody2D _rigidBody2D;
        private SpriteRenderer _spriteRenderer;
        private PlayerMovement _playerMovement;
        private Transform _transform;

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
                lateralMovementStats: this.playerStats.playerLateralMovementStats,
                verticalMovementStats: this.playerStats.playerVerticalMovementStats,
                transform: this._transform);

            this._resetPlayerStats();
        }

        private void _getChildComponents()
        {
            this._rigidBody2D = GetComponent<Rigidbody2D>();
            this._animator = GetComponent<Animator>();
            this._spriteRenderer = GetComponent<SpriteRenderer>();
            this._transform = GetComponent<Transform>();
        }

        private void _resetPlayerStats()
        {
            this._playerCurrentHealth = this.playerStats.playerInitialHealth;
            this._playerCurrentPotions = this.playerStats.playerInitialPotions;
            this.PlayerChangeHealth(0f);
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

        public void RelocatePlayer(Transform transform)
        {
            this._playerMovement.RelocatePlayer(transform);
        }

        #endregion

        // Update is called once per frame
        private void Update()
        {
            this._playerMovement.UpdateActions();
        }
    }
}