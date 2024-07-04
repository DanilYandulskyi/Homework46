using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;

    public event Action Changed;

    public float CurrentValue { get; private set; }
    public float MaxValue => _maxValue;

    public void Start()
    {
        CurrentValue = _maxValue;
        Changed?.Invoke();
    }

    public void Decrease(int value)
    {
        if (value < 0)
        {
            return;
        }

        CurrentValue -= value;

        if (CurrentValue <= 0)
        {
            CurrentValue = 0;
            Destroy(gameObject);
        }

        Changed?.Invoke();
    }

    public void Increase(int value)
    {
        if (value < 0)
        {
            return;
        }

        CurrentValue += value;

        if (CurrentValue > _maxValue)
        {
            CurrentValue = _maxValue;
        }

        Changed?.Invoke();
    }
}
