using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    private bool _isInteracted;

    private void Awake()
    {
        PlayerInteraction.OnInteractEvent.AddListener(HandleInteract);
    }

    private void HandleInteract(string chestName)
    {
        if (name == chestName)
        {
            if (_isInteracted)
            {
                _isInteracted = false;
                gameObject.SetActive(true);
            }
            else
            {
                _isInteracted = true;
                CoinActivation.Instance.ActivateCoin(transform.position);
                gameObject.SetActive(false);
            }
        }
    }
}