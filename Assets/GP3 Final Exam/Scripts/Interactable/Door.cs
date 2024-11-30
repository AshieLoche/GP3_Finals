using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public bool isInteracted;
    public TextMeshProUGUI Tooltips;

    private void OnCollisionEnter(Collision collision)
    {
        Tooltips.gameObject.SetActive(true);
        Tooltips.text = "Press E to Open Door";
        if (collision.gameObject.TryGetComponent<PlayerMovements>(out PlayerMovements player)) 
        {
            player.interactable = gameObject;
            player.isInteractable = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Tooltips.gameObject.SetActive(false);
        if (collision.gameObject.TryGetComponent<PlayerMovements>(out PlayerMovements player))
        {
            player.interactable =  null;
            player.isInteractable = false;
        }
    }

    public void Interacted() 
    {
        if (!isInteracted)
        {
            isInteracted = true;
            gameObject.SetActive(false);
        }
        else 
        {
            isInteracted = false;
            gameObject.SetActive(true);
        }
    }
}
