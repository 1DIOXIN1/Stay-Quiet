using UnityEngine;

using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]private Transform player;    // Ссылка на стартовую точку
    private Animator animator;
    private AudioSource audioSource;
    public float detectionRange = 10f;   // Дальность обнаружения игрока
    public float chaseDuration = 5f;     // Продолжительность преследования
    public LayerMask layerMask;
    private NavMeshAgent navMeshAgent;
    private float chaseTimer;
    private bool isChasing = false;
    private Vector3 originalPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        originalPosition = transform.position;
    }

    void Update()
    {
        if(!player)
            return;
        
        // Проверка, находится ли игрок в пределах дальности обнаружения
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            Debug.Log("123");
            // Стреляем рейкастом в направлении игрока
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.position - transform.position, out hit,10,layerMask))
            {
                if (hit.collider.GetComponent<Player>())
                {
                    if (!isChasing)
                    {
                        Debug.Log("456");
                        isChasing = true;
                        chaseTimer = chaseDuration;
                        animator.SetInteger("State",1);
                        audioSource.Play();
                    }
                    // Начинаем преследование игрока
                }
            }
        }

        // Преследование игрока или возврат на стартовую точку
        if (isChasing)
        {
            Debug.Log("789");
            navMeshAgent.SetDestination(player.position);
            chaseTimer -= Time.deltaTime;

            if (chaseTimer <= 0f || distanceToPlayer > detectionRange)
            {
                // Время истекло или игрок вышел из дальности обнаружения
                isChasing = false;
                navMeshAgent.SetDestination(originalPosition);
            }
        }
        else
        {
            Debug.Log("111");
            if (Vector3.Distance(transform.position, originalPosition) <= navMeshAgent.stoppingDistance+1)
            {
                // Достигли стартовой точки, устанавливаем анимацию состояния 0
                animator.SetInteger("State", 0);
            }
            navMeshAgent.SetDestination(originalPosition);
        }
    }
}