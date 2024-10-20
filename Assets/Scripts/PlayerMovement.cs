using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
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
        if(canMove && _controller.enabled)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 directionMove = transform.right * horizontalInput + transform.forward * verticalInput;
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
