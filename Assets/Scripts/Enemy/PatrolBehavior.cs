using UnityEngine;
using UnityEngine.AI;

public class PatrolBehavior : IPatrolBehavior
{
    private Transform[] patrolPoints;
    private int currentPointIndex = 0;
    private NavMeshAgent agent;

    public PatrolBehavior(NavMeshAgent agent, Transform[] patrolPoints)
    {
        this.agent = agent;
        this.patrolPoints = patrolPoints;
    }

    public void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.destination = patrolPoints[currentPointIndex].position;
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }
    }
}
