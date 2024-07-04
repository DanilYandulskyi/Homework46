using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VampireZone : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _stealingHealth;
    [SerializeField] private float _radius;
    [SerializeField] private Color _changingColor;
    [SerializeField] private float _activatedTime;
    
    private Color _defaultColor;
    private Coroutine _coroutine;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _defaultColor = _image.color;
    }

    private void Update()
    {
        KeyCode key = KeyCode.RightControl;

        if (Input.GetKey(key))
        {
            _image.color = _changingColor;

            HandleColliders();
        }
    }

    private IEnumerator StealHealth(Enemy enemy)
    {
        for (int i = 0; i < _stealingHealth; i++)
        {
            yield return new WaitForSeconds(_activatedTime / _stealingHealth);

            enemy.TakeDamage(1);
            _player.Heal(1);
        }

        _image.color = _defaultColor;
        _coroutine = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void HandleColliders()
    {
        if (_coroutine == null)
        {
            Enemy enemy = GetEnemy();

            if (enemy != null)
            {
                _coroutine = StartCoroutine(StealHealth(enemy));
            }
        }
    }

    private Enemy GetEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out Enemy enemy))
            {
                return enemy;
            }
        }

        return null;
    }
}