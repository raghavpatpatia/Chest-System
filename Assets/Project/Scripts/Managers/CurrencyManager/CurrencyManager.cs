using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager>
{
    private int totalCoins;
    private int totalGems;
    [SerializeField] private int coins = 1000;
    [SerializeField] private int gems = 20;
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        totalCoins = coins;
        totalGems = gems;
        Events.Instance.InvokeCoinsUpdate(totalCoins);
        Events.Instance.InvokeGemsUpdate(totalGems);
    }


    public void AddCoins(int amount)
    {
        totalCoins += amount;
        Events.Instance.InvokeCoinsUpdate(totalCoins);
    }

    public void AddGems(int amount)
    {
        totalGems += amount;
        Events.Instance.InvokeGemsUpdate(totalGems);
    }

    public bool RemoveCoins(int amount)
    {
        if (totalCoins - amount < 0) return false;
        totalCoins -= amount;
        Events.Instance.InvokeCoinsUpdate(totalGems);
        return true;
    }

    public bool RemoveGems(int amount)
    {
        if (totalGems - amount < 0) return false;
        totalGems -= amount;
        Events.Instance.InvokeGemsUpdate(totalGems);
        return true;
    }
}