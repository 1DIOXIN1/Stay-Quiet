using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<IUsable> usableItems = new List<IUsable>();

    public void AddItem(IUsable item)
    {
        usableItems.Add(item); // ��������� ������� � ���������
    }

    public IUsable GetFirstItem()
    {
        if (usableItems.Count > 0)
        {
            return usableItems[0]; // ���������� ������ �������
        }
        return null; // ���� ��������� ����
    }

    public void RemoveFirstItem()
    {
        if (usableItems.Count > 0)
        {
            usableItems.RemoveAt(0); // ������� ������ �������
        }
    }
}
