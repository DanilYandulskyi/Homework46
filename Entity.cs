using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Health _health;
    
    protected Health Health => _health;
    protected int Damage => _damage;

    public void TakeDamage(int damage)
    {
        _health.Decrease(damage);
    }

    public void Heal(int addingHealth)
    {
        _health.Increase(addingHealth);
    }
}
