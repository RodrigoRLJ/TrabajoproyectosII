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

    public static event Action MoveUpKeyPressed;
    public static event Action MoveDownKeyPressed;
    public static event Action MoveRightKeyPressed;
    public static event Action MoveLeftKeyPressed;
    public static event Action PlayerTouchedGround;

    private void _checkPlayerMovement()
    {
        if (Input.GetKeyDown(name: "w"))
            MoveUpKeyPressed?.Invoke();
        if (Input.GetKey(name: "s"))
            MoveDownKeyPressed?.Invoke();
        if (Input.GetKey(name: "d"))
            MoveRightKeyPressed?.Invoke();
        if (Input.GetKey(name: "a"))
            MoveLeftKeyPressed?.Invoke();
    }

    public static void PlayerFell()
    {
        PlayerTouchedGround?.Invoke();
    }

    public void Update()
    {
        this._checkPlayerMovement();
    }
}