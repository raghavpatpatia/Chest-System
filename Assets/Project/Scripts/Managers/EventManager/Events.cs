using System;

public class Events : Singleton<Events>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public event Action<int> CoinsUpdate;
    public event Action<int> GemsUpdate;
    public void InvokeCoinsUpdate(int amount)
    {
        CoinsUpdate?.Invoke(amount);
    }
    public void InvokeGemsUpdate(int amount)
    {
        GemsUpdate?.Invoke(amount);
    }
}