using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UITextHealth : HealthUI
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void UpdateUI()
    {
        _text.text = $"{Health.CurrentValue} / {Health.MaxValue}";
    }
}
