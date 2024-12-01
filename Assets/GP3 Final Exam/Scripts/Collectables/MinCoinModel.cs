public class MinCoinModel : ObjectModel
{
    public static MinCoinModel Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}