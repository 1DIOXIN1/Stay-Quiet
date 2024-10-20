using UnityEngine;

public class KeyItem : MonoBehaviour, IPickable, IUsable
{
    public void OnPickUp()
    {
        Debug.Log("Ключ подобран!");
        Destroy(gameObject); // Удаляем предмет после подбора
    }

    public void Use(GameObject target)
    {
        if (target.CompareTag("Door"))
        {
            Debug.Log("Ключ использован на двери.");
            target.GetComponent<Door>().Unlock(target); // Пример использования на двери
        }
    }
}
