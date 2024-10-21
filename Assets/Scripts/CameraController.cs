using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 2.0f; //Чувствительность мыши
    [SerializeField] private float _maxYAngle; //Макс угол вращения по вертикали
    private ShakeCamera _cameraShake;
    private float _rotationX = 0.0f;
    private void Start() 
    {
        _cameraShake = GetComponent<ShakeCamera>();
    }
    private void Update() {
        //Получение ввода от мыши
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Вращение по горизонтали
        transform.parent.Rotate(Vector3.up * mouseX * _sensitivity);

        //Вращение по вертикали
        _rotationX -= mouseY * _sensitivity;
        _rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);
        transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
    
    float move = Input.GetAxis("Vertical");
    if (Mathf.Abs(move) > 0) // Если персонаж двигается
    {
        _cameraShake.Shake();
    }
    }

}
