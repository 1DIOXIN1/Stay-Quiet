using UnityEngine;

public class OutlineController : MonoBehaviour
{
    
    [SerializeField] private Material firstOutlineMaterial;    // Материал с эффектом контура
    [SerializeField] private Material secondOutlineMaterial; 

    private Outline objectOutline;

    void Start()
    {
        // Сохраняем исходный материал объекта
        objectOutline = GetComponent<Outline>();
    }

    // Метод для включения или отключения контура
    public void SetOutline(bool isOutlined)
    {
        if (isOutlined)
        {
            objectOutline.enabled = true;  // 
        }
        else
        {
            objectOutline.enabled = false;  // 
        }
    }
}
