using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement movement;
    private Inventory inventory; // Ссылка на инвентарь

    public float interactionRange = 3.0f; // Дистанция взаимодействия

    void Start()
    {
        movement = GetComponent<PlayerMovement>();

        inventory = GetComponent<Inventory>();


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract(inventory); // Подбор или использование предмета
        }
    }

    private void TryInteract(Inventory inventory)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Луч из камеры
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            // Попробуем сначала подобрать предмет
            IPickable pickableItem = hit.collider.GetComponent<IPickable>();
            if (pickableItem != null)
            {
                pickableItem.OnPickUp(); // Подбор предмета

                // Проверим, можно ли этот предмет использовать
                IUsable usableItem = hit.collider.GetComponent<IUsable>();
                if (usableItem != null)
                {
                    inventory.AddItem(usableItem); // Добавляем в инвентарь
                }
                return; // Если предмет был подобран, завершаем метод
            }

            // Если предмета нет, попробуем использовать предмет из инвентаря
            IUsable itemInInventory = inventory.GetFirstItem();
            if (itemInInventory != null)
            {
                itemInInventory.Use(hit.collider.gameObject); // Используем предмет
                inventory.RemoveFirstItem(); // Удаляем предмет из инвентаря после использования
            }
        }
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
