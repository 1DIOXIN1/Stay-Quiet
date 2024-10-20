using UnityEngine;
using UnityEngine.AI;

public class Patrol : IPatrolBehavior
{
    private NavMeshAgent _agent;
    private Vector3[] _waypoints;
    private int _currentWaypointIndex;

    public Patrol(NavMeshAgent agent, Vector3[] waypoints)
    {
        _agent = agent;
        _waypoints = waypoints;
        _currentWaypointIndex = 0;
    }

    public void Patrolling()
    {
        if (_agent.remainingDistance < 0.5f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            _agent.SetDestination(_waypoints[_currentWaypointIndex]);
        }
    }
}
