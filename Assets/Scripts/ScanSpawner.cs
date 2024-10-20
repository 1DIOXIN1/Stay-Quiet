using UnityEngine;

public class ScanSpawner : MonoBehaviour
{
    [SerializeField] private GameObject echoWavePrefab;  // Префаб сферы эхолокатора
    [SerializeField] private Transform spawnPoint;       // Точка, где будет спавниться сфера

    void Update()
    {
        // Проверяем нажатие клавиши пробел (Space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEchoWave();
        }
    }

    // Метод для спавна сферы эхолокатора
    void SpawnEchoWave()
    {
        // Проверяем, назначен ли префаб и точка спавна
        if (echoWavePrefab != null && spawnPoint != null)
        {
            Instantiate(echoWavePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
