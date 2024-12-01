public class MediumCoinModel : ObjectModel
{
    public static MediumCoinModel Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}