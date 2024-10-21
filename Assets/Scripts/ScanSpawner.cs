using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScanSpawner : MonoBehaviour
{
    [SerializeField] private GameObject echoWavePrefab;  // Префаб сферы эхолокатора
    private GameObject currentEchoWave;
    [SerializeField] private Transform spawnPoint;       // Точка, где будет спавниться сфера
    [SerializeField] private UniversalRendererData rendererData;
    
    private bool isCoolDown = false; 

    void Update()
    {

        // Проверяем нажатие клавиши пробел (Space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnemyController.DeathScreen += StopUsingEcho;
            if (!isCoolDown)
            {
                if (rendererData != null)
                    // Ищем FullScreenPassRendererFeature среди rendererFeatures
                    for (int i = 0; i < rendererData.rendererFeatures.Count; i++)
                        if (rendererData.rendererFeatures[i] is FullScreenPassRendererFeature) 
                            // Отключаем FullScreenPassRendererFeature
                            rendererData.rendererFeatures[i].SetActive(true);
                StartCoroutine(CoolDownEchoWave());
                SpawnEchoWave();
            }
        }
    }

    // Метод для спавна сферы эхолокатора
    void SpawnEchoWave()
    {
        // Проверяем, назначен ли префаб и точка спавна
        if (echoWavePrefab != null && spawnPoint != null)
        currentEchoWave = echoWavePrefab;
            Instantiate(currentEchoWave, spawnPoint.position, spawnPoint.rotation);
    }

    IEnumerator CoolDownEchoWave()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(5);
        isCoolDown = false;
    }

    private void StopUsingEcho()
    {
        currentEchoWave.SetActive(false);
    }
}
