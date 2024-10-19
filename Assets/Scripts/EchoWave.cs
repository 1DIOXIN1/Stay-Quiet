using UnityEngine;

public class EchoWave : MonoBehaviour
{
    [SerializeField]private float _waveSpeed = 5f;
    [SerializeField]private float _maxScaleWave = 10f;

    private float _currentWaveRadius = 1f;
    void Update()
    {
        if(transform.localScale.x < _maxScaleWave)
        {
            transform.localScale += Vector3.one * _waveSpeed * Time.deltaTime;
            _currentWaveRadius = transform.localScale.x / 2; // Радиус волны
        }
        else{
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
    Collider[] hitColliders = Physics.OverlapSphere(transform.position, _currentWaveRadius);
    foreach (var hitCollider in hitColliders)
    {
        // Здесь можно добавить логику подсветки объекта
    }
    }
}
