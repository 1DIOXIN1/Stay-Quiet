using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private PlayerMovement movement;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        movement = GetComponent<PlayerMovement>();
    }

    public void DisableMovement()
    {
        movement.enabled = false;
    }

    public void EnableMovement()
    {
        movement.enabled = true;
    }

    public void SetVisibility(bool isVisible)
    {
        GetComponent<MeshRenderer>().enabled = isVisible;
    }
}
