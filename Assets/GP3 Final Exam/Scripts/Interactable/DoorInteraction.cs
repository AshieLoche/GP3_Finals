using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    private bool _isInteracted;

    private void Awake()
    {
        PlayerInteraction.OnInteractEvent.AddListener(HandleInteract);
    }

    private void HandleInteract(string doorName)
    {
        if (name == doorName)
        {
            if (_isInteracted)
            {
                _isInteracted = false;
                gameObject.SetActive(true);
            }
            else
            {
                _isInteracted = true;
                gameObject.SetActive(false);
            }
        }
    }
}