using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Expone solo un vector 2 para el offset, para evitar el bug por offset 0 en la z
    [SerializeField] private Vector2 offset;

    //La velocidad a la que la cámara sigue al jugador
    [SerializeField] private float damping;

    //El componente transform del jugador (el que la cámara va a seguir)
    private Transform _targetTransform;

    //Atributo usado para la referencia en la función SmoothDamp
    private Vector3 _velocity = Vector3.zero;

    private void Start()
    {
        //Busca el componente transform del jugador y se lo asigna a su atributo.
        this._targetTransform = GameObject.FindWithTag("Player").transform;
    }

    //Se usa el LateUpdate porque siempre se llama después del Update
    //De este forma el jugador recalcula su posición, y solo después la cámara empieza a moverse.
    private void LateUpdate()
    {
        //Calcula la posición objetivo de la cámara, se basa en la posición del jugador y el offset (desviación) que queremos
        //El menos 1 es fijo porque sino la camara se mete en el personaje y no se ve nada.
        Vector3 targetPosition = _targetTransform.position + new Vector3(offset.x, offset.y, -1);

        //Cambia la posición de la cámara a la nueva posición con la función SmoothDamp, que mueve un objeto de posición X a Y gradualmente y sin pasarse.
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, damping);
    }
}