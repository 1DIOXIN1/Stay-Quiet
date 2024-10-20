using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private PlayerMovement movement;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        movement = GetComponent<PlayerMovement>();
    }

    // Отключаем движение
    public void DisableMovement()
    {
        movement.DisableMovement();
    }

    // Включаем движение
    public void EnableMovement()
    {
        movement.EnableMovement();
    }

    // Устанавливаем видимость игрока
    public void SetVisibility(bool isVisible)
    {
        GetComponent<MeshRenderer>().enabled = isVisible;
    }
}
