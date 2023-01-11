using TMPro;
using UnityEngine;

public class HPController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [Space]
    [SerializeField] private TextMeshProUGUI _healthUI;
 
    private void OnEnable()
    {
        EventBus.OnTakeDamage += UpdateHealthUI;
    }
    private void OnDisable()
    {
        EventBus.OnTakeDamage -= UpdateHealthUI;
    }
    private void UpdateHealthUI()
    {
        _healthUI.text = $"HP : {(Mathf.Round(_player.CurrentHealth * 10 ) / 10)}";
    }
}
