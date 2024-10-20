using UnityEngine;

public class KeyItem : MonoBehaviour, IPickable, IUsable
{
    public void OnPickUp()
    {
        Debug.Log("���� ��������!");
        Destroy(gameObject); // ������� ������� ����� �������
    }

    public void Use(GameObject target)
    {
        if (target.CompareTag("Door"))
        {
            Debug.Log("���� ����������� �� �����.");
            target.GetComponent<Door>().Unlock(target); // ������ ������������� �� �����
        }
    }
}
