using UnityEngine;
using UnityEngine.Events;

public class CoinCollision : MonoBehaviour
{
    public static UnityEvent<string> OnCollectEvent = new();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnCollectEvent.Invoke(name);
            gameObject.SetActive(false);
        }
    }
}
