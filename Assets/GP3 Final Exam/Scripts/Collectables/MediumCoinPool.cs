public class MediumCoinPool : ObjectPool
{
    public static MediumCoinPool Instance;

    protected override void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
