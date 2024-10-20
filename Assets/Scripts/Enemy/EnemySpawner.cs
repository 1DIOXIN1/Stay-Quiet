using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector3[] patrolPoints;
    
    void Start()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        Animator animator = enemy.GetComponent<Animator>();
        
        EnemyAIFactory factory = new EnemyAIFactory();
        EnemyAI enemyAI = factory.CreateEnemyAI(agent, animator, patrolPoints);
    }
}

