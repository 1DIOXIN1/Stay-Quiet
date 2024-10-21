using System;
using UnityEngine;
using UnityEngine.UI;

public class HideInteraction : MonoBehaviour
{
    [SerializeField] private Transform _hidingSpot; // Место, куда переместится игрок при прятании
    [SerializeField] private GameObject _uiPressForHide;
    [SerializeField] private Text _textPressToHide;
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
            _uiPressForHide.SetActive(true);
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInRange = false; // Игрок вышел из зоны укрытия
            _uiPressForHide.SetActive(false);
            
        }
    }
    

private void EnterHiding()
{
    Debug.Log("123");
    if (_controller != null && _controller.enabled)
    {
        _textPressToHide.text = "Нажмите [E], чтобы выйти";
        _controller.enabled = false;
        ImHide.Invoke();
        Debug.Log("789");
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
    Debug.Log("000");
    Debug.Log("Игрок спрятался");
}

private void ExitHiding()
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
        _textPressToHide.text = "Нажмите [E], чтобы спрятаться";
        _controller.enabled = true;  // Включаем контроллер после перемещения
    }

    Debug.Log("Игрок вышел из укрытия");
}

}
