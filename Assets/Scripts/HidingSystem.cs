using UnityEngine;

public class HidingSystem : MonoBehaviour
{
    private Player player;
    private IHidable currentHideableObject;
    private bool isHiding = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        // Если игрок в зоне укрытия и нажата клавиша E
        if (currentHideableObject != null && Input.GetKeyDown(KeyCode.E))
        {
            if (isHiding)
            {
                currentHideableObject.ExitHiding(player);
                isHiding = false;
            }
            else
            {
                currentHideableObject.EnterHiding(player);
                isHiding = true;
            }
        }
    }

    // Когда игрок входит в зону объекта укрытия
    void OnTriggerEnter(Collider other)
    {
        IHidable hideable = other.GetComponent<IHidable>();
        if (hideable != null)
        {
            currentHideableObject = hideable;
        }
    }

    // Когда игрок выходит из зоны объекта укрытия
    void OnTriggerExit(Collider other)
    {
        IHidable hideable = other.GetComponent<IHidable>();
        if (hideable != null && hideable == currentHideableObject)
        {
            currentHideableObject = null;
        }
    }
}
