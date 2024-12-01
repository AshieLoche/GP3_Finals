using UnityEngine;

public class CoinActivation : MonoBehaviour
{
    private int _index;
    private GameObject _coin;

    public static CoinActivation Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void GetCoin(string coinType)
    {
        _index = Random.Range(0, 3);

        if (_index == 0)
        {
            _coin = coinType switch 
            {
                "Coin" => MinCoinPool.Instance.GetObject(),
                "Coin Reserve" => MinCoinPool.Instance.GetReserveObject(),
                _ => null
            };
        }
        else if (_index == 1)
        {
            _coin = coinType switch
            {
                "Coin" => MediumCoinPool.Instance.GetObject(),
                "Coin Reserve" => MediumCoinPool.Instance.GetReserveObject(),
                _ => null
            };
        }
        else if (_index == 2)
        {
            _coin = coinType switch
            {
                "Coin" => MaxCoinPool.Instance.GetObject(),
                "Coin Reserve" => MaxCoinPool.Instance.GetReserveObject(),
                _ => null
            };
        }

        _coin.SetActive(true);
    }

    public void ActivateCoin(Vector3 pos)
    {
        GetCoin("Coin Reserve");

        _coin.transform.position = pos;
    }

    public void ActivateCoins(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GetCoin("Coin");
        }
    }
}