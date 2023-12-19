using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager>
{
    public int totalCoins { get; private set; }
    public int totalGems { get; private set; }
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


    private void AddCoins(int amount)
    {
        totalCoins += amount;
        Events.Instance.InvokeCoinsUpdate(totalCoins);
    }

    private void AddGems(int amount)
    {
        totalGems += amount;
        Events.Instance.InvokeGemsUpdate(totalGems);
    }

    public void RemoveCoins(int amount)
    {
        totalCoins -= amount;
        Events.Instance.InvokeCoinsUpdate(totalGems);
    }

    public void RemoveGems(int amount)
    {
        totalGems -= amount;
        Events.Instance.InvokeGemsUpdate(totalGems);
    }

    public void AddCurrency(int coins, int gems)
    {
        AddCoins(coins);
        AddGems(gems);
    }
}