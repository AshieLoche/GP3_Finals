using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner Instance;

    [SerializeField] private int _coinAmount;
    [SerializeField] private int _coinReserveAmount;
    public int CoinAmount { get { return _coinAmount; } }
    public int CoinReserveAmount { get { return _coinReserveAmount; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SetCoins();
    }

    private void SetCoins()
    {
        MinCoinPool.Instance.SetObjects(_coinAmount);
        MediumCoinPool.Instance.SetObjects(_coinAmount);
        MaxCoinPool.Instance.SetObjects(_coinAmount);

        CoinActivation.Instance.ActivateCoins(_coinAmount);

        MinCoinPool.Instance.SetReserveObjects(_coinReserveAmount);
        MediumCoinPool.Instance.SetReserveObjects(_coinReserveAmount);
        MaxCoinPool.Instance.SetReserveObjects(_coinReserveAmount);
    }
}