using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isLocked = true;

    public void Unlock(GameObject obj)
    {
        if (isLocked)
        {
            isLocked = false;
            Destroy(obj);
            Debug.Log("Дверь разблокирована!");
        }
    }
}
