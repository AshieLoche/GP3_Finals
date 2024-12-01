using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject _interactable;
    private bool _isInteractable;

    public static UnityEvent<string> OnInteractEvent = new();

    private void Awake()
    {
        InteractableCollision.OnCollideEvent.AddListener(HandleCollide);
        InteractableCollision.OnSeparateEvent.AddListener(HandleSeparate);
    }

    private void Update()
    {
        Interact();
    }

    private void HandleCollide(GameObject interactable)
    {
        _interactable = interactable;
        _isInteractable = true;
    }

    private void HandleSeparate()
    {
        _interactable = null;
        _isInteractable = false;
    }

    private void Interact()
    {
        if (_isInteractable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnInteractEvent.Invoke(_interactable.name);

                _isInteractable = false;
                _interactable = null;
            }
        }
    }

}