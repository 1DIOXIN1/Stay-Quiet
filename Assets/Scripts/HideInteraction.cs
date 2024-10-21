using System;
using UnityEngine;

public class HideInteraction : MonoBehaviour
{
    [SerializeField] private Transform _hidingSpot; // Место, куда переместится игрок при прятании
    private bool _isInRange = false; // Находится ли игрок в зоне укрытия
    private bool _isHiding = false; // Спрятан ли игрок
    private GameObject _player; // Игрок
    public static event Action ImHide;
    public static event Action ImNotHide;

    private CharacterController _controller;

private void Start() 
{
    _player = GameObject.FindWithTag("Player");
    _controller = _player.GetComponent<CharacterController>();
}
    void Update()
    {
        if (_isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (_isHiding)
            {
                // Вылезаем из укрытия
                ExitHiding();
            }
            else
            {
                // Прячемся
                EnterHiding();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInRange = true; // Игрок вошел в зону укрытия
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInRange = false; // Игрок вышел из зоны укрытия
        }
    }

void EnterHiding()
{
    if (_controller != null && _controller.enabled)
    {
        _controller.enabled = false;
        ImHide.Invoke();
    }

    // Перемещаем игрока в укрытие
    _player.transform.position = _hidingSpot.position;
    _isHiding = true;

    // Отключаем видимость игрока
    _player.GetComponent<MeshRenderer>().enabled = false;

    if (_controller != null)
    {
        _controller.enabled = true;
        ImNotHide.Invoke();  // Включаем контроллер после перемещения
    }

    Debug.Log("Игрок спрятался");
}

void ExitHiding()
{
    if (_controller != null && _controller.enabled)
    {
        _controller.enabled = false;  // Отключаем контроллер перед перемещением
        ImNotHide.Invoke();
    }

    // Возвращаем игрока на исходную позицию
    _player.transform.position = transform.position + new Vector3(1, 0, 0);
    _isHiding = false;

    // Включаем видимость игрока
    _player.GetComponent<MeshRenderer>().enabled = true;

    if (_controller != null)
    {
        _controller.enabled = true;  // Включаем контроллер после перемещения
    }

    Debug.Log("Игрок вышел из укрытия");
}

}
