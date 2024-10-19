using System.Collections;
using UnityEngine;

public class EchoWave : MonoBehaviour
{
    [SerializeField] private GameObject _scanSphere;

    [SerializeField] private float _waveSpeed = 5f;
    [SerializeField] private float _zoomRate = 5f;
    [SerializeField] private float _maxScale = 10f;
    [SerializeField] private float _outlineDuration = 2f;  // Время, на которое остаётся контур
    void Update()
    {
        if (transform.localScale.x < _maxScale)
        {
            transform.localScale += Vector3.one * Time.deltaTime * _zoomRate;
            float currentWaveRadius = transform.localScale.x / 2;
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, currentWaveRadius);

            foreach (var hitCollider in hitColliders)
            {
                OutlineController outlineScript = hitCollider?.GetComponent<OutlineController>();
                if (outlineScript != null)
                {
                    outlineScript.SetOutline(true);  // Включаем контур
                    StartCoroutine(DisableOutlineAfterTime(outlineScript, _outlineDuration));  // Отключаем контур через время
                }
            }
        }
        else
        {
            StartCoroutine(DestroyObject(gameObject, _outlineDuration));
        }
        transform.Translate(Vector3.forward * _waveSpeed * Time.deltaTime);
    }

    // Корутин для отключения контура
    IEnumerator DisableOutlineAfterTime(OutlineController outlineScript, float duration)
    {
        yield return new WaitForSeconds(duration);
        outlineScript.SetOutline(false);  // Отключаем контур
    }

    IEnumerator DestroyObject(GameObject obj, float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(obj);
    }
}
