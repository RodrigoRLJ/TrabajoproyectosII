using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 offset;
    [SerializeField] private float damping;

    private Transform _targetTransform;

    private void Start()
    {
        this._targetTransform = GameObject.FindWithTag("Player").transform;
    }

    private Vector3 _velocity = Vector3.zero;

    //Se usa el LateUpdate porque siempre se llama después del Update
    //De este forma el jugador recalcula su posición, y solo después la cámara empieza a moverse.
    private void LateUpdate()
    {
        //El menos 1 es fijo porque sino la camara se mete en el personaje y no se ve nada.
        Vector3 targetPosition = _targetTransform.position + new Vector3(offset.x, offset.y, -1);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, damping);
    }
}