using System;
using UnityEngine;
using UnityEngine.UIElements;

public class EventSystem : MonoBehaviour
{
    public static event Action PlayerTouchedGround;
    public static event Action ChangeFastMenuState;
    public static event Action<float, float> PlayerHealthChanged;

    private void _checkKeyEvents()
    {
        if (Input.GetKeyUp(key: KeyCode.Escape))
        {
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
}