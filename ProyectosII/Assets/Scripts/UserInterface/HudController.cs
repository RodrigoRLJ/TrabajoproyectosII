using System;
using System.Collections;
using System.Collections.Generic;
using Entities.Player;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class HudController : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        EventSystem.PlayerHealthChanged += UpdateHealthValue;
    }

    private void OnDestroy()
    {
        EventSystem.PlayerHealthChanged -= UpdateHealthValue;
    }

    private void UpdateHealthValue(float playerMaxHealth, float playerCurrentHealth)
    {
        this._slider.value = (playerCurrentHealth / playerMaxHealth);
    }
}