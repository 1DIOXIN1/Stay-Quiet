using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _uiWin;
    private bool isLocked = true;

    public void Unlock(GameObject obj)
    {
        if (isLocked)
        {
            isLocked = false;
            _uiWin.SetActive(true);
            Destroy(obj);
        }
    }
}
