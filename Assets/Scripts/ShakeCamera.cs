using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
// Параметры тряски
    [SerializeField] private float amplitude = 0.1f;  // Сила тряски
    [SerializeField] private float frequency = 10f;   // Частота тряски

    // Для включения и выключения тряски
    [SerializeField] private bool isShaking = false;
    private Vector3 initialPosition; // Исходная позиция камеры

    private void Start()
    {
        initialPosition = transform.localPosition; // Сохраняем исходную позицию камеры
    }

    // Метод для тряски камеры
    public void Shake()
    {
        if (isShaking)
        {
        float offsetX = Mathf.PerlinNoise(Time.time * frequency, 0f) * amplitude - amplitude / 2f;
        float offsetY = Mathf.PerlinNoise(0f, Time.time * frequency) * amplitude - amplitude / 2f;

        transform.localPosition = new Vector3(initialPosition.x + offsetX, initialPosition.y + offsetY, initialPosition.z);
        }
        else
        {
            transform.localPosition = initialPosition;
        }
    }
}
