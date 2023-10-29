using System;
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

        //Stat objects
        private PlayerSpeedStats _playerSpeedStats;
        private PlayerControlStats _playerControlStats;


        //Movement objects
        private Vector2 _vector2;
        private Transform _playerTransform;

        #endregion

        public PlayerMovement(Rigidbody2D rigidBody2D, Animator animator, PlayerSpeedStats playerSpeedStats,
            PlayerControlStats playerControlStats)
        {
            //Initiate player components
            this._rigidBody2D = rigidBody2D;
            this._animator = animator;

            //Initiate player stats
            this._playerSpeedStats = playerSpeedStats;
            this._playerControlStats = playerControlStats;

            //Initiate other objects
            this._vector2 = new Vector2(x: 0f, y: 0f);
        }

        #region Event subscription

        public void SubscribeToFunctions()
        {
            /*EventSystem.Instance.MoveUpKeyPressed += this._jump;
            EventSystem.Instance.MoveDownKeyPressed += this._moveDown;*/
            EventSystem.Instance.MoveRightKeyPressed += this._moveRight;
            EventSystem.Instance.MoveLeftKeyPressed += this._moveLeft;
        }

        public void UnsubscribeToFunctions()
        {
            /*EventSystem.Instance.MoveUpKeyPressed -= this._jump;
            EventSystem.Instance.MoveDownKeyPressed -= this._moveDown;*/
            EventSystem.Instance.MoveRightKeyPressed -= this._moveRight;
            EventSystem.Instance.MoveLeftKeyPressed -= this._moveLeft;
        }

        #endregion

        #region Vector manipulation

        /**
         * Fast getter to get current horizontal speed
         */
        private float _getCurrentVectorX()
        {
            return this._vector2.x;
        }

        /**
         * Fast getter to get current vertical speed
         */
        private float _getCurrentVectorY()
        {
            return this._vector2.y;
        }

        /**
         * Changes the current X speed without altering the Y speed
         */
        private void _changeSpeedVectorX(float newX)
        {
            this._changeSpeedVector(newX: newX, newY: this._vector2.y);
        }

        /**
         * Changes the current Y speed without altering the X speed
         */
        private void _changeSpeedVectorY(float newY)
        {
            this._changeSpeedVector(newX: this._vector2.x, newY: newY);
        }

        /**
         * Changes the current X ad Y speed
         */
        private void _changeSpeedVector(float newX, float newY)
        {
            this._vector2.Set(newX, newY);
        }

        #endregion

        #region Horizontal movement

        public void _moveRight()
        {
            //Check if it changes direction
            //***It it does, decelerate rapidly
            //***If it doesn't
            //******Check how close player is to speed limit
            //*********If it's there don't increase the speed
            //*********Otherwise accelerate
        }

        public void _moveLeft()
        {
        }
        //TODO: move left
        //TODO: move right
        //TODO: player acceleration over time
        //TODO: player deceleration if not moving 
        //TODO: player cut acceleration when near max speed
        //TODO: player add extra force on turn around
        //TODO: player limitate fall speed
        //TODO: player bonus on jump apex

        #endregion

        #region Verical movement

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