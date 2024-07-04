using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string RunTrigger = "Run";
    private const string JumpTrigger = "Jump";
    private const string IdleTrigger = "Idle";
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRunAnimation()
    {
        _animator.SetTrigger(RunTrigger);
    }

    public void PlayJumpAnimation()
    {
        _animator.SetTrigger(JumpTrigger);
    }

    public void PlayIdleAnimation()
    {
        _animator.SetTrigger(IdleTrigger);
    }
}
