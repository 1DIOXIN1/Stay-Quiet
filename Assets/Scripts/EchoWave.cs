using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EchoWave : MonoBehaviour
{
    [SerializeField] private GameObject _scanSphere;
    [SerializeField] private UniversalRendererData rendererData;
    // [SerializeField] private Material _trying;
    
    // [SerializeField] private float _waveSpeed = 5f;
    [SerializeField] private float _zoomRate = 5f;
    [SerializeField] private float _maxScale = 10f;
    [SerializeField] private float _outlineDuration = 2f;  // Время, на которое остаётся контур

    //private void Start()
    //{
    //    Renderer obj = GetComponent<Renderer>();
    //    obj.sharedMaterial;

    //}

    void Update()
    {
        if (transform.localScale.x < _maxScale)
        {
            transform.localScale += Vector3.one * Time.deltaTime * _zoomRate;
        }
        else
        {
            StartCoroutine(DestroyObject(gameObject, _outlineDuration));
        }
        // transform.Translate(Vector3.forward * _waveSpeed * Time.deltaTime);
    }

    // Корутин для удаления сферы
    IEnumerator DestroyObject(GameObject obj, float duration)
    {
        yield return new WaitForSeconds(duration);
        if (rendererData != null)
        {
            // Ищем FullScreenPassRendererFeature среди rendererFeatures
            for (int i = 0; i < rendererData.rendererFeatures.Count; i++)
            {
                if (rendererData.rendererFeatures[i] is FullScreenPassRendererFeature)
                {
                    // Отключаем FullScreenPassRendererFeature
                    rendererData.rendererFeatures[i].SetActive(false);
                }
            }
        }
        Destroy(obj);
    }
}
