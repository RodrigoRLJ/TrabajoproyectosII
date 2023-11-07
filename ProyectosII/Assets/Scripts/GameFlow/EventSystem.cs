using System;
using UnityEngine;
using UnityEngine.UIElements;

public class EventSystem : MonoBehaviour
{
    #region Singleton guarantee

    private static EventSystem _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(_instance);
        }
    }

    #endregion

    public static event Action MoveUpKeyPressed;
    public static event Action MoveDownKeyPressed;
    public static event Action MoveRightKeyPressed;
    public static event Action MoveLeftKeyPressed;
    public static event Action PlayerTouchedGround;
    public static event Action ChangeFastMenuState;
    public static event Action<float, float> PlayerHealthChanged;

    private void _checkKeyEvents()
    {
        if (Input.GetKeyDown(key: KeyCode.W) || Input.GetKeyDown(key: KeyCode.Space))
            MoveUpKeyPressed?.Invoke();

        if (Input.GetKey(key: KeyCode.S))
            MoveDownKeyPressed?.Invoke();

        if (Input.GetKey(key: KeyCode.D))
            Debug.Log("FOrward!!!!!");
        MoveRightKeyPressed?.Invoke();

        if (Input.GetKey(key: KeyCode.A))
            MoveLeftKeyPressed?.Invoke();

        if (Input.GetKeyUp(key: KeyCode.Escape))
        {
            Debug.Log("Ezcapingg");
            ChangeFastMenuState?.Invoke();
        }
    }

    public static void PlayerFell()
    {
        PlayerTouchedGround?.Invoke();
    }

    public static void PlayerNewHealth(float playerMaxHealth, float playerCurrentHealth)
    {
        PlayerHealthChanged?.Invoke(playerMaxHealth, playerCurrentHealth);
    }

    public void Update()
    {
        this._checkKeyEvents();
    }
}