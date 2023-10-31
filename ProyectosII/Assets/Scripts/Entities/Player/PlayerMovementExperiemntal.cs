using System;
using UnityEngine;

namespace Entities.Player
{
    public class PlayerMovementExperimental
    {
        #region Unused examples

        /*private void _Movement()
        {
            if (Input.GetKey("d"))
            {
                _movesRight = true;
                _rigidBody2D.velocity = _GetMovementVetcor();
                /*_animator.SetBool("Running", true);#1#
                _playerTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetKey("a"))
            {
                _movesRight = false;
                _rigidBody2D.velocity = _GetMovementVetcor();
                //_animator.SetBool("Running", true);
                _playerTransform.rotation = Quaternion.Euler(0, 180, 0);
            }
            /*else
            {
                _animator.SetBool("Running", false);
            }#1#

            Saltar();
        }


        private void Saltar() //no furula
        {
            var permisoSaltar = false;
            if (gameObject.transform.position.y <= 0) permisoSaltar = true;
            if (Input.GetKey("w") && gameObject.transform.position.y < 1f && permisoSaltar)
            {
                gameObject.transform.Translate(0, 1f * Time.deltaTime, 0);
            }
            else
            {
                permisoSaltar = false;
                if (gameObject.transform.position.y > 0) gameObject.transform.Translate(0, -1f * Time.deltaTime, 0);
            }
        }*/

        #endregion

        #region Attribute declaration

        //Animation objects
        private Rigidbody2D _rigidBody2D;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        //Stat objects
        private readonly PlayerSpeedStats _playerSpeedStats;
        private readonly PlayerControlStats _playerControlStats;


        //Movement objects
        private Transform _playerTransform;

        //Player movement data
        private float _accelerationAmount;
        private float _decelerationAmount;

        #endregion

        public PlayerMovementExperimental(
            Rigidbody2D rigidBody2D,
            Animator animator,
            SpriteRenderer spriteRenderer,
            PlayerSpeedStats playerSpeedStats,
            PlayerControlStats playerControlStats)
        {
            //Initiate player components
            this._rigidBody2D = rigidBody2D;
            this._animator = animator;
            this._spriteRenderer = spriteRenderer;

            //Initiate player stats
            this._playerSpeedStats = playerSpeedStats;
            this._playerControlStats = playerControlStats;

            //Initiate movement data
            this._accelerationAmount = 0;
            this._decelerationAmount = 0;
        }

        #region Event subscription

        public void SubscribeToEvents()
        {
            EventSystem.MoveUpKeyPressed += this._jump;
            //EventSystem.MoveDownKeyPressed += this._moveDown;
            EventSystem.MoveRightKeyPressed += this._moveRight;
            EventSystem.MoveLeftKeyPressed += this._moveLeft;
            EventSystem.PlayerTouchedGround += this._playerTouchedGround;
        }

        public void UnsubscribeFromEvents()
        {
            EventSystem.MoveUpKeyPressed -= this._jump;
            //EventSystem.MoveDownKeyPressed -= this._moveDown;
            EventSystem.MoveRightKeyPressed -= this._moveRight;
            EventSystem.MoveLeftKeyPressed -= this._moveLeft;
            EventSystem.PlayerTouchedGround -= this._playerTouchedGround;
        }

        #endregion

        #region Vector manipulation

        /**
         * Fast getter to get current horizontal speed
         */
        private float _getCurrentVectorX()
        {
            return this._rigidBody2D.velocity.x;
        }

        /**
         * Fast getter to get current vertical speed
         */
        private float _getCurrentVectorY()
        {
            return this._rigidBody2D.velocity.y;
        }

        /**
         * Changes the current X speed without altering the Y speed
         */
        private void _changeSpeedVectorX(float newX)
        {
            this._changeSpeedVector(newX: newX, newY: this._getCurrentVectorY());
        }

        /**
         * Changes the current Y speed without altering the X speed
         */
        private void _changeSpeedVectorY(float newY)
        {
            this._changeSpeedVector(newX: this._getCurrentVectorX(), newY: newY);
        }

        /**
         * Changes the current X ad Y speed
         */
        private void _changeSpeedVector(float newX, float newY)
        {
            this._rigidBody2D.velocity = new Vector2(newX, newY);
        }

        #endregion

        #region Horizontal movement

        private void _moveRight()
        {
            this._changeSpeedVectorX(this._playerSpeedStats.playerMaxSpeed);
            this._spriteRenderer.flipX = false;
            //Check if it changes direction
            //***It it does, decelerate rapidly
            //***If it doesn't
            //******Check how close player is to speed limit
            //*********If it's there don't increase the speed
            //*********Otherwise accelerate
        }

        private void _moveLeft()
        {
            this._changeSpeedVectorX(-this._playerSpeedStats.playerMaxSpeed);
            this._spriteRenderer.flipX = true;
        }

        //TODO: move left
        //TODO: move right
        //TODO: player acceleration over time
        //TODO: player deceleration if not moving 
        //TODO: player cut acceleration when near max speed
        private bool _checkNeedToAccelerate()
        {
            return this._playerSpeedStats.playerMaxSpeed > this._accelerationAmount;
        }
        //TODO: player add extra force on turn around
        //TODO: player limitate fall speed
        //TODO: player bonus on jump apex

        #endregion

        #region Verical movement

        private void _jump()
        {
            this._changeSpeedVectorY(5);
        }

        private void _playerTouchedGround()
        {
            Debug.Log("I fell!");
        }
        //TODO: limit player time on early jump release
        //TODO: player extra time to jump since grounded (Coyote time)
        //TODO: player check jumps available
        //TODO: decrease player gravity on jump apex
        //TODO: add a jump buffer to jump when you hit the ground
        //TODO: allow player to reach platform if gets near to it

        #endregion

        public void UpdateActions()
        {
        }
    }
}