using UnityEngine;

namespace GameObjects
{
    /**
     * Datos de la plataforma
     */
    public class PlatformData : MonoBehaviour
    {
        /**
         * Tiempo que la plataforma está estable
         */
        [SerializeField] private int _stableTime;

        /**
         * Si la plataforma se destruye al tocar el suelo
         */
        [SerializeField] private bool _destroyOnFall;

        /**
         * Si la plataforma vuelve a su posición original al cabo de un tiempo.
         */
        [SerializeField] private bool _resetPlatform;

        private float _startX;
        private float _startY;

        void Start()
        {
            this._startX = this.gameObject.transform.position.x;
            this._startY = this.gameObject.transform.position.y;
        }

        //Make getters for all private atributes
        public int GetStableTime()
        {
            return this._stableTime;
        }

        public bool GetDestroyOnFall()
        {
            return this._destroyOnFall;
        }

        public bool GetResetPlatform()
        {
            return this._resetPlatform;
        }

        public float GetStartX()
        {
            return this._startX;
        }

        public float GetStartY()
        {
            return this._startY;
        }
    }
}