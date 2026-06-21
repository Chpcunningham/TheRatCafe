using UnityEngine;
using UnityEngine.InputSystem;
using Assets.Scripts.Interfaces;
using Unity.VisualScripting;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float radius = 2f;
    [SerializeField] private InputActionReference interactAction;
    public LayerMask collisionMask;
    private IInteractable currentInteractable;

    private void OnEnable()
    {
        if (interactAction != null)
        {
            interactAction.action.performed += OnInteract;
        }
    }

    private void OnDisable()
    {
        if (interactAction != null)
        {
            interactAction.action.performed -= OnInteract;
        }
    }
    private void OnInteract(InputAction.CallbackContext context)
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    private void CheckForInteractable()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(this.transform.position, radius, collisionMask);

        currentInteractable = null;

        foreach (var hit in hits) {
            if(hit.TryGetComponent(out IInteractable interactable))
            {
                currentInteractable = interactable;
                break;
            }
        }
    }
    public void Update()
    {
        CheckForInteractable();
    }
}
