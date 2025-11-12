using UnityEngine;

public class PlayerAnimator : IPlayerAnimator
{
    private Animator _animator;

    public PlayerAnimator(Animator animator) =>
        _animator = animator;

    public void OnIdle()
    {
        _animator.SetTrigger(AnimatorData.Idle);
    }

    public void OnJump()
    {
        _animator.SetTrigger(AnimatorData.Jump);
    }

    public void OnMove()
    {
        _animator.SetTrigger(AnimatorData.Run);
    }
}
