using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private IPatrolBehavior _patrolBehavior;
    private IAnimationController _animationController;

    // Зависимости через конструктор
    public EnemyAI(IPatrolBehavior patrolBehavior, IAnimationController animationController)
    {
        _patrolBehavior = patrolBehavior;
        _animationController = animationController;
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _patrolBehavior.Patrolling();
    }

    public void ChangeAnimation(string animationName)
    {
        _animationController.PlayAnimation(animationName);
    }
}