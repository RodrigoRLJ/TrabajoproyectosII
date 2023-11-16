using System;
using System.Threading;
using UnityEngine;

namespace Entities.Player
{
    public class PlayerMovement
    {
        #region Attribute declaration

        //Movement objects
        private Transform _playerTransform;

        //Controller objects
        private VectorController _vectorController;
        private VerticalMovement _verticalMovement;
        private LateralMovement _lateralMovement;

        #endregion

        public PlayerMovement(
            Rigidbody2D rigidBody2D,
            Animator animator,
            SpriteRenderer spriteRenderer,
            PlayerLateralMovement lateralMovementStats,
            PlayerVerticalMovement verticalMovementStats,
            Transform transform,
            PlayerFeetController playerFeet)
        {
            //Initiate player components
            this._playerTransform = transform;

            this._vectorController = new VectorController(rigidBody2D);

            this._lateralMovement = new LateralMovement(
                animator: animator,
                spriteRenderer: spriteRenderer,
                lateralMovementStats: lateralMovementStats,
                vectorController: this._vectorController
            );

            this._verticalMovement = new VerticalMovement(
                animator: animator,
                spriteRenderer: spriteRenderer,
                verticalMovementStats: verticalMovementStats,
                vectorController: this._vectorController,
                lateralMovement: this._lateralMovement,
                playerFeet: playerFeet
            );
        }

        public void RelocatePlayer(Transform transform)
        {
            this._playerTransform.position = transform.position;
        }


        public void UpdateActions()
        {
            this._lateralMovement.UpdateActions();
            this._verticalMovement.UpdateActions();
        }
    }
}