using UnityEngine;

public class AnimationController : IAnimationController
{
    private Animator _animator;

    public AnimationController(Animator animator)
    {
        _animator = animator;
    }

    public void PlayAnimation(string animationName)
    {
        _animator.Play(animationName);
    }
}
