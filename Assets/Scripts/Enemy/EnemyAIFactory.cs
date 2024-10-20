using UnityEngine;
using UnityEngine.AI;

public class EnemyAIFactory : MonoBehaviour
{
    public EnemyAI CreateEnemyAI(NavMeshAgent agent, Animator animator, Vector3[] waypoints)
    {
        IPatrolBehavior patrolBehavior = new Patrol(agent, waypoints);
        IAnimationController animationController = new AnimationController(animator);
        
        return new EnemyAI(patrolBehavior, animationController);
    }
}
