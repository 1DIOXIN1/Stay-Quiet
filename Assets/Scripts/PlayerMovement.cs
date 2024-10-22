using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _gravityForce = 20f;
    private CharacterController _controller;
    private Vector3 directionMove;

    private bool canMove = true; // Переменная для контроля движения

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
    void Update()
    {
        Move();
    }

    // Отключаем возможность движения

    private void Move()
    {
        if(canMove && _controller.enabled)
        {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        directionMove = transform.right * horizontalInput + transform.forward * verticalInput;
        directionMove.y -= 9.81f * Time.deltaTime * _gravityForce;
        _controller.Move(directionMove * _moveSpeed * Time.deltaTime);
        }
    }
    public void DisableMovement()
    {
        canMove = false;
        _controller.enabled = false;
    }

    // Включаем возможность движения
    public void EnableMovement()
    {
        canMove = true;
        _controller.enabled = false;
    }
}
