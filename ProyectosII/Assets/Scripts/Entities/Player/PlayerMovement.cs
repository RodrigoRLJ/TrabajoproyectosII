using System;
using System.Threading;
using UnityEngine;

namespace Entities.Player
{
    public class PlayerMovement
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

        //Player jump data
        public const double MIN_JUMP_TIME = 0.10;
        private int _usedJumps;
        private double _timeSinceJump;
        private bool _jumped;

        #endregion

        public PlayerMovement(
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

            //Initiate jump data
            this._resetJumpData();
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
            this._animator.SetBool("isRunning", true);

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

        /**
         * Activated when the player presses the jump key
         * Change later on to take into account the time the key is pressed
         */
        private void _jump()
        {
            if (this._CheckcanJump())
            {
                this._animator.SetBool("startsJump", true);
                this._usedJumps++;
                this._changeSpeedVectorY(10);
                this._timeSinceJump = 0D;
                this._jumped = true;
                Debug.Log("I jumped on : " + Time.time);
            }
        }

        /**
         * Effects once the player has touched the ground.
         */
        private void _playerTouchedGround()
        {
            this._resetJumpData();
        }

        /**
         * Checks if the player still has any jump left.
         */
        private bool _CheckcanJump()
        {
            return (this._usedJumps < this._playerControlStats.playerJumpsAvailable) /* &&
                   (this._timeSinceJump > PlayerMovement.MIN_JUMP_TIME)*/;
        }

        /**
         * Resets the jump data to allow the player to jump again.
         */
        private void _resetJumpData()
        {
            this._usedJumps = 0;
            this._timeSinceJump = 0;
            this._jumped = false;
        }

        //TODO: limit player time on early jump release
        //TODO: player extra time to jump since grounded (Coyote time)
        //TODO: decrease player gravity on jump apex
        //TODO: add a jump buffer to jump when you hit the ground (the engine seems to do it fine though)
        //TODO: allow player to reach platform if gets near to it

        #endregion

        public void UpdateActions()
        {
            if (this._jumped)
            {
                this._timeSinceJump += Time.deltaTime;

                if (this._timeSinceJump > 0.10)
                {
                    this._animator.SetBool("startsJump", false);
                    this._animator.SetBool("doesJump", true);
                }
            }
        }
    }
}