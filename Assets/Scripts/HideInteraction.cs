using UnityEngine;

public class HideInteraction : MonoBehaviour
{
    [SerializeField] private Transform hidingSpot; // Место, куда переместится игрок при прятании
    private bool isInRange = false; // Находится ли игрок в зоне укрытия
    private bool isHiding = false; // Спрятан ли игрок
    private GameObject player; // Игрок

private void Start() 
{
    player = GameObject.FindWithTag("Player");
}
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (isHiding)
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
            isInRange = true; // Игрок вошел в зону укрытия
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false; // Игрок вышел из зоны укрытия
        }
    }

    void EnterHiding()
    {
        player.transform.position = hidingSpot.position; // Перемещаем игрока на место укрытия
        isHiding = true;
        // Можно добавить логику для отключения видимости игрока
        player.GetComponent<MeshRenderer>().enabled = false;
        Debug.Log("123");
    }

    void ExitHiding()
    {
        isHiding = false;
        // Возвращаем игрока обратно (например, на исходную позицию перед шкафом)
        player.transform.position = transform.position + new Vector3(1, 0, 0); // Возвращаем игрока чуть в сторону от шкафа
        player.GetComponent<MeshRenderer>().enabled = true;
    }
}
