using UnityEngine;

public class HideableObject : MonoBehaviour, IHidable
{
    public Transform hidingSpot;

    public void EnterHiding(Player player)
    {
        // Отключаем CharacterController
        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false; // Отключаем контроллер

            // Перемещаем игрока к точке укрытия
            Vector3 newPosition = hidingSpot.position;
            newPosition.y = player.transform.position.y; // Сохраняем высоту

            // Устанавливаем позицию игрока
            player.transform.position = newPosition;

            // Прячем игрока
            player.SetVisibility(false);
            Debug.Log("Игрок спрятался");
        }
    }

    public void ExitHiding(Player player)
    {
        // Получаем CharacterController игрока
        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller != null)
        {
            // Сохраняем текущую высоту
            float currentY = player.transform.position.y;

            // Перемещаем игрока чуть в сторону
            Vector3 moveDirection = transform.position + new Vector3(1, 0, 0) - player.transform.position;
            moveDirection.y = 0; // Не изменяем высоту

            // Отключаем гравитацию или иные силы на момент выхода
            player.GetComponent<Rigidbody>().useGravity = false; // Отключаем гравитацию

            // Устанавливаем новую позицию
            player.transform.position += moveDirection;

            // Восстанавливаем высоту игрока
            Vector3 fixedPosition = player.transform.position;
            fixedPosition.y = currentY;
            player.transform.position = fixedPosition;

            // Включаем CharacterController
            controller.enabled = true;

            // Включаем гравитацию обратно
            player.GetComponent<Rigidbody>().useGravity = true; // Включаем гравитацию снова

            // Показываем игрока
            player.SetVisibility(true);
            Debug.Log("Игрок вышел из укрытия");
        }
    }
}
