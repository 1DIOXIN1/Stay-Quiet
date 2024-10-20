using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScanSpawner : MonoBehaviour
{
    [SerializeField] private GameObject echoWavePrefab;  // Префаб сферы эхолокатора
    [SerializeField] private Transform spawnPoint;       // Точка, где будет спавниться сфера
    [SerializeField] private UniversalRendererData rendererData;

    void Update()
    {
        // Проверяем нажатие клавиши пробел (Space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rendererData != null)
            {
                // Ищем FullScreenPassRendererFeature среди rendererFeatures
                for (int i = 0; i < rendererData.rendererFeatures.Count; i++)
                {
                    if (rendererData.rendererFeatures[i] is FullScreenPassRendererFeature)
                    {
                        // Отключаем FullScreenPassRendererFeature
                        rendererData.rendererFeatures[i].SetActive(true);
                    }
                }
            }
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
        else
        {
            // Debug.LogError("Echo wave prefab or spawn point not assigned!");
        }
    }
}
