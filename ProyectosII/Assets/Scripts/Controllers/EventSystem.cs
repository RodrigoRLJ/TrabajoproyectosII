using System;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    #region Singleton guarantee

    public static EventSystem Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(Instance);
        }
    }

    #endregion

    public event Action MoveUpKeyPressed;
    public event Action MoveDownKeyPressed;
    public event Action MoveRightKeyPressed;
    public event Action MoveLeftKeyPressed;

    private void _checkPlayerMovement()
    {
        if (Input.GetKey("w"))
            MoveUpKeyPressed?.Invoke();
        if (Input.GetKey("s"))
            MoveDownKeyPressed?.Invoke();
        if (Input.GetKey("d"))
            MoveRightKeyPressed?.Invoke();
        if (Input.GetKey("a"))
            MoveLeftKeyPressed?.Invoke();
    }

    public void Update()
    {
        this._checkPlayerMovement();
    }
}