using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool isInteracted;
    public TextMeshProUGUI Tooltips;
    public List<Coin> coins;
    public GameObject coinParents;

    private void OnCollisionEnter(Collision collision)
    {
        Tooltips.gameObject.SetActive(true);
        Tooltips.text = "Press E to Open Chest";
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
            player.interactable = null;
            player.isInteractable = false;
        }
    }

    public void Interacted()
    {
        if (!isInteracted)
        {
            isInteracted = true;
            SpawnCoin();
            gameObject.SetActive(false);
        }
        else
        {
            isInteracted = false;
            gameObject.SetActive(true);
        }
    }

    public void SpawnCoin() 
    {
        int randomCoin = Random.Range(0, coins.Count);
        Instantiate(coins[randomCoin], transform.position, Quaternion.identity, coinParents.transform);
    }
}
