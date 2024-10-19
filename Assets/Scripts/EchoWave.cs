using System.Collections;
using UnityEngine;

public class EchoWave : MonoBehaviour
{
    [SerializeField] private float _waveSpeed = 5f;
    [SerializeField] private float _maxScale = 10f;
    [SerializeField] private float _outlineDuration = 2f;  // Время, на которое остаётся контур

    void Update()
    {
        if (transform.localScale.x < _maxScale)
        {
            transform.localScale += Vector3.one * _waveSpeed * Time.deltaTime;
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
