using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : Entity
{
    private bool _isGrouneded = false;
    private PlayerAnimator _animator;
    private Mover _mover;
    private Jumper _jumper;
    
    private void Awake()
    {
        _jumper = GetComponent<Jumper>();
        _mover = GetComponent<Mover>();
        _animator = GetComponent<PlayerAnimator>();
    }

    public void Update()
    {
        Vector2 posibleDirection = Vector2.right;
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += posibleDirection;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction -= posibleDirection;
        }
       
        if (Input.GetKeyDown(KeyCode.Space) & _isGrouneded)
        {
            _jumper.Jump();
            _animator.PlayJumpAnimation();
        }

        if (direction != Vector2.zero)
        {
            _animator.PlayRunAnimation();
            _mover.Move(direction);
        }
        else 
        {
            _animator.PlayIdleAnimation();
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        _isGrouneded = other.TryGetComponent(out Platform platform);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (_isGrouneded == other.TryGetComponent(out Platform platform))
        {
            _isGrouneded = false;
        }
    }
}
