public class MaxCoinModel : ObjectModel
{
    public static MaxCoinModel Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}