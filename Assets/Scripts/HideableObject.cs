using UnityEngine;

public class HideableObject : MonoBehaviour, IHidable
{
    public Transform hidingSpot;

    public void EnterHiding(Player player)
    {
        // Отключаем движение и прячем игрока
        player.DisableMovement();
        player.transform.position = hidingSpot.position;
        player.SetVisibility(false);
        Debug.Log("Игрок спрятался");
    }

    public void ExitHiding(Player player)
    {
        // Включаем движение и показываем игрока
        player.transform.position = transform.position + new Vector3(1, 0, 0); // Смещаем на шаг в сторону
        player.EnableMovement();
        player.SetVisibility(true);
        Debug.Log("Игрок вышел из укрытия");
    }
}
