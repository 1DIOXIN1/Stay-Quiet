using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _gravityForce = 20f;
    private CharacterController _controller;
    private bool canMove = true; // Переменная для контроля движения

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 directionMove = transform.right * horizontalInput + transform.forward * verticalInput;
        directionMove.y -= 9.81f * Time.deltaTime * _gravityForce;
        if(canMove && _controller.enabled)
        {
            _controller.Move(directionMove * _moveSpeed * Time.deltaTime);
        }
    }

    // Отключаем возможность движения
    public void DisableMovement()
    {
        canMove = false;
    }

    // Включаем возможность движения
    public void EnableMovement()
    {
        canMove = true;
    }
}
