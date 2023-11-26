using TMPro;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;


public class HudController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI healthNumber;

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
        this.slider.value = (playerCurrentHealth / playerMaxHealth);
        this.healthNumber.SetText(playerCurrentHealth.ToString());
    }
}