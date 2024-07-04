using UnityEngine;

public abstract class HealthUI : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected Health Health => _health;

    private void OnEnable()
    {
        _health.Changed += UpdateUI;
    }

    private void OnDestroy()
    {
        _health.Changed -= UpdateUI;
    }

    protected abstract void UpdateUI();
}