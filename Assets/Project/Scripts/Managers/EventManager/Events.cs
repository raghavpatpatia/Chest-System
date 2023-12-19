using System;
using UnityEngine;

public class Events : Singleton<Events>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public event Action<Controller> OnChestClicked;
    public event Action OnSlotsFull;
    public event Action<int> CoinsUpdate;
    public event Action<int> GemsUpdate;
    public event Action OnQueueFull;

    public void InvokeSlotsFull()
    {
        OnSlotsFull?.Invoke();
    }

    public void InvokeOnQueueFull()
    {
        OnQueueFull?.Invoke();
    }

    public void InvokeCoinsUpdate(int amount)
    {
        CoinsUpdate?.Invoke(amount);
    }
    public void InvokeGemsUpdate(int amount)
    {
        GemsUpdate?.Invoke(amount);
    }

    internal void InvokeOnChestClicked(Controller controller)
    {
        OnChestClicked?.Invoke(controller);
    }
}