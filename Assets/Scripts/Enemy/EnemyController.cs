using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement; // Для перезагрузки сцены

public class EnemyController : MonoBehaviour
{
    [SerializeField] private AudioSource _screamSound;
    [SerializeField] private AudioSource _movementSound;
    public Transform player; // Игрок, которого враг будет искать
    [SerializeField] private GameObject screamerCanvas; // UI-элемент для скримера
    public float detectionRange = 5.0f; // Радиус обнаружения
    public static event Action DeathScreen;

    private IPatrolBehavior patrolBehavior;
    private EnemyAnimator enemyAnimator;
    private bool isPlayerDetected = false;
    private bool canDetectPlayer = true;

    [Obsolete]
    private void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        Animator animator = GetComponent<Animator>();
        HideInteraction.ImHide += StopDetectPlayer;
        HideInteraction.ImNotHide += StartDetectPlayer;
        Transform[] patrolPoints = FindObjectsOfType<Transform>().Where(t => t.CompareTag("PatrolPoint")).ToArray();
        patrolBehavior = new PatrolBehavior(agent, patrolPoints);
        enemyAnimator = new EnemyAnimator(animator);
        _movementSound.Play();
        screamerCanvas.SetActive(false); // Скример по умолчанию скрыт
    }

    private void Update()
    {
        // Если игрок не найден, продолжаем патрулировать
        if (!isPlayerDetected)
        {
            
            patrolBehavior.Patrol();
            if (GetComponent<NavMeshAgent>().velocity.magnitude > 0.1f)
            {
                enemyAnimator.PlayWalkAnimation();
            }
            else
            {
                enemyAnimator.StopWalkAnimation();
            }
        }
        if (canDetectPlayer)
        {
            DetectPlayer();

        }

    }

    // Обнаружение игрока
    private void DetectPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            OnPlayerDetected();
        }
    }
    
    private void StopDetectPlayer()
    {
        canDetectPlayer = false;
    }
    private void StartDetectPlayer()
    {
        canDetectPlayer = true;
    }


    // Действие при обнаружении игрока
    private void OnPlayerDetected()
    {
        isPlayerDetected = true;
        ShowScreamer();
    }

    // Показ скримера
    private void ShowScreamer()
    {
        _screamSound.Play();
        isPlayerDetected = false;
        screamerCanvas.SetActive(true); // Включаем скример
        Invoke("ShowDeathScreen", 2f); // Через 2 секунды показываем экран смерти
    }

    // Показ экрана смерти
    private void ShowDeathScreen()
    {
        // Можно добавить анимацию смерти или текст
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Перезагрузка сцены
    }
}
