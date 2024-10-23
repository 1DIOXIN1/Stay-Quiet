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

private void Start() 
{
    _player = GameObject.FindWithTag("Player");
}
    void Update()
    {
        if (_isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (_isHiding) ExitHiding(); // Вылезаем из укрытия
            else EnterHiding(); // Прячемся
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

        _textPressToHide.text = "Нажмите [E], чтобы выйти";
        ImHide.Invoke();

        // Перемещаем игрока в укрытие
        _player.transform.position = _hidingSpot.position;
        _isHiding = true;
        // Отключаем видимость игрока
        _player.GetComponent<MeshRenderer>().enabled = false;
    }


    private void ExitHiding()
    {
        // Возвращаем игрока на исходную позицию
        _player.transform.position = transform.position + new Vector3(1, 0, 0);
        _isHiding = false;

        // Включаем видимость игрока
        _player.GetComponent<MeshRenderer>().enabled = true;
        _textPressToHide.text = "Нажмите [E], чтобы спрятаться";
        ImNotHide.Invoke();
        Debug.Log("Игрок вышел из укрытия");
    }
}
