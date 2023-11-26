using UnityEngine;

namespace Entities.Player
{
    public class VectorController
    {
        private Rigidbody2D _rigidBody2D;

        public VectorController(Rigidbody2D rigidBody2D)
        {
            this._rigidBody2D = rigidBody2D;
        }

        /**
         * Fast getter to get current horizontal speed
         */
        private float GetCurrentVectorX()
        {
            return this._rigidBody2D.velocity.x;
        }

        /**
         * Fast getter to get current vertical speed
         */
        private float GetCurrentVectorY()
        {
            return this._rigidBody2D.velocity.y;
        }

        /**
         * Changes the current X speed without altering the Y speed
         */
        public void ChangeSpeedVectorX(float newX)
        {
            this.ChangeSpeedVector(newX: newX, newY: this.GetCurrentVectorY());
        }

        /**
         * Changes the current Y speed without altering the X speed
         */
        public void ChangeSpeedVectorY(float newY)
        {
            this.ChangeSpeedVector(newX: this.GetCurrentVectorX(), newY: newY);
        }

        /**
         * Changes the current X ad Y speed
         */
        public void ChangeSpeedVector(float newX, float newY)
        {
            this._rigidBody2D.velocity = new Vector2(newX, newY);
        }
    }
}