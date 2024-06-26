using TMPro;

public class MoneyController
{
    private TextMeshProUGUI coinsText;
    private TextMeshProUGUI gemsText;
    private int coinsAmount;
    private int gemsAmount;
    private EventService eventService;
    public MoneyController(int startingCoins, int startingGems, TextMeshProUGUI coinsText, TextMeshProUGUI gemsText, EventService eventService)
    {
        this.coinsText = coinsText;
        this.gemsText = gemsText;
        this.coinsAmount = startingCoins;
        SetCoinsText(coinsAmount);
        this.gemsAmount = startingGems;
        SetGemsText(gemsAmount);
        this.eventService = eventService;
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        eventService.OnAddingCoinsAndGems.AddListener(AddCoinsAndGems);
        eventService.OnRemovingGems.AddListener(RemoveGems);
    }

    private void SetCoinsText(int amount) => coinsText.text = amount.ToString();
    private void SetGemsText(int amount) => gemsText.text = amount.ToString();

    private void AddCoinsAndGems(int coinsAmount, int gemsAmount)
    {
        this.coinsAmount += coinsAmount;
        SetCoinsText(this.coinsAmount);
        this.gemsAmount += gemsAmount;
        SetGemsText(this.gemsAmount);
    }

    private void RemoveGems(int amount)
    {
        if (amount < this.gemsAmount && this.gemsAmount - amount >= 0)
        {
            this.gemsAmount -= amount;
            SetGemsText(this.gemsAmount);
        }
        else
        {
            eventService.ShowNotificationBox.Invoke("Not enough Gems", "Not enough Gems to unlock. Try again later!");
        }
    }

    ~MoneyController()
    {
        eventService.OnAddingCoinsAndGems.RemoveListener(AddCoinsAndGems);
        eventService.OnRemovingGems.RemoveListener(RemoveGems);
    }
}