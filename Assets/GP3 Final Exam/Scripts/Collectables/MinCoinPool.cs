public class MinCoinPool : ObjectPool
{
    public static MinCoinPool Instance;

    protected override void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}