using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InteractableCollision : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tooltips;

    public static UnityEvent<GameObject> OnCollideEvent = new();
    public static UnityEvent OnSeparateEvent = new();

    private void OnCollisionEnter(Collision collision)
    {
        _tooltips.gameObject.SetActive(true);

        if (collision.gameObject.CompareTag("Player"))
        {
            OnCollideEvent.Invoke(gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _tooltips.gameObject.SetActive(false);

        if (collision.gameObject.CompareTag("Player"))
        {
            OnSeparateEvent.Invoke();
        }
    }
}