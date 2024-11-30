using UnityEngine;

public class Coin : MonoBehaviour
{
    public int givePoints;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMovements>(out PlayerMovements player)) 
        {
            player.Collected(givePoints);
            Destroy(gameObject);
        }
    }
}
