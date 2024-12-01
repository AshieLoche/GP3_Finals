using UnityEngine;

public class MaxCoinPool : ObjectPool
{
    public static MaxCoinPool Instance;

    protected override void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
