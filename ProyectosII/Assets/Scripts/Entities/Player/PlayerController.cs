using System;
using Entities.Player;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    #region Atribute declaration

    [SerializeField] private PlayerStats _playerStats;
    private Animator _animator;
    private Rigidbody2D _rigidBody2D;
    private PlayerMovement _playerMovement;

    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        this._rigidBody2D = GetComponent<Rigidbody2D>();
        this._animator = GetComponent<Animator>();

        this._playerMovement = new PlayerMovement(rigidBody2D: this._rigidBody2D, animator: this._animator,
            playerSpeedStats: this._playerStats.playerSpeedStats,
            playerControlStats: this._playerStats.playerControlStats);

        this._playerMovement.SubscribeToEvents();
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