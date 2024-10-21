using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement; // Для перезагрузки сцены
using UnityEngine.UI; // Для UI скримера

public class EnemyController : MonoBehaviour
{
    public Transform player; // Игрок, которого враг будет искать
    public Canvas screamerCanvas; // UI-элемент для скримера
    public float detectionRange = 5.0f; // Радиус обнаружения
    public static event Action DeathScreen;

    private IPatrolBehavior patrolBehavior;
    private EnemyAnimator enemyAnimator;
    private bool isPlayerDetected = false;

    private void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        Animator animator = GetComponent<Animator>();
        
        Transform[] patrolPoints = FindObjectsOfType<Transform>().Where(t => t.CompareTag("PatrolPoint")).ToArray();
        patrolBehavior = new PatrolBehavior(agent, patrolPoints);
        enemyAnimator = new EnemyAnimator(animator);

        screamerCanvas.enabled = false; // Скример по умолчанию скрыт
    }

    private void Update()
    {
        // Если игрок не найден, продолжаем патрулировать
        if (!isPlayerDetected && screamerCanvas.enabled == false)
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

        DetectPlayer();
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

    // Действие при обнаружении игрока
    private void OnPlayerDetected()
    {
        isPlayerDetected = true;
        ShowScreamer();
    }

    // Показ скримера
    private void ShowScreamer()
    {
        screamerCanvas.enabled = true; // Включаем скример
        Invoke("ShowDeathScreen", 2f); // Через 2 секунды показываем экран смерти
        DeathScreen.Invoke();
    }

    // Показ экрана смерти
    private void ShowDeathScreen()
    {
        // Можно добавить анимацию смерти или текст

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Перезагрузка сцены
    }
}
