using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scorePointsText;
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _chestText;
    [SerializeField] private GameObject _winPanel;
    private int _scoreGathered, _coinsCollected, _chestOpened, _totalCoins;

    public static UnityEvent OnWinEvent = new();

    private void Awake()
    {
        PlayerInteraction.OnInteractEvent.AddListener(HandleInteract);
        CoinCollision.OnCollectEvent.AddListener(HandleCollect);
    }

    private void Start()
    {
        _scoreGathered = _coinsCollected = _chestOpened = 0;
        _totalCoins = CoinSpawner.Instance.CoinAmount + CoinSpawner.Instance.CoinReserveAmount;
    }

    private void HandleInteract(string interactableName)
    {
        if (interactableName.Contains("Chest"))
        {
            _chestText.text = $"Chest: {++_chestOpened}";
        }
    }

    private void HandleCollect(string name)
    {
        if (name.Contains("MinCoin"))
        {
            _scorePointsText.text = $"Chest: {_scoreGathered += MinCoinModel.Instance.Points}";
        }
        else if (name.Contains("MediumCoin"))
        {
            _scorePointsText.text = $"Chest: {_scoreGathered += MediumCoinModel.Instance.Points}";
        }
        else if (name.Contains("MaxCoin"))
        {
            _scorePointsText.text = $"Chest: {_scoreGathered += MaxCoinModel.Instance.Points}";
        }

        _coinsText.text = $"Coins: {++_coinsCollected}";

        GameStatus();
    }

    private void GameStatus()
    {
        if (_coinsCollected == _totalCoins)
        {
            OnWinEvent.Invoke();
            _winPanel.SetActive(true);
        }
    }
}