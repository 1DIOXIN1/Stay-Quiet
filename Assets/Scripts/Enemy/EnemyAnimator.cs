using UnityEngine;

public class EnemyAnimator
{
    private Animator animator;

    public EnemyAnimator(Animator animator)
    {
        this.animator = animator;
    }

    public void PlayWalkAnimation()
    {
        animator.SetBool("isWalking", true);
    }

    public void StopWalkAnimation()
    {
        animator.SetBool("isWalking", false);
    }
}
