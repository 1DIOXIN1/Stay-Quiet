using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private IPatrolBehavior patrolBehavior;
    private EnemyAnimator enemyAnimator;

    private void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        Animator animator = GetComponent<Animator>();
        
        Transform[] patrolPoints = FindObjectsOfType<Transform>().Where(t => t.CompareTag("PatrolPoint")).ToArray();
        patrolBehavior = new PatrolBehavior(agent, patrolPoints);
        
        // Передаем компонент Animator в класс EnemyAnimator
        enemyAnimator = new EnemyAnimator(animator);
    }


    private void Update()
{
    patrolBehavior.Patrol();
    
    // Проверка движения агента, чтобы включить/выключить анимацию
    if (GetComponent<NavMeshAgent>().velocity.magnitude > 0.1f)
    {
        enemyAnimator.PlayWalkAnimation();
    }
    else
    {
        enemyAnimator.StopWalkAnimation();
    }
}

}
