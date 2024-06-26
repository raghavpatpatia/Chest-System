using UnityEngine;

public class ChestService
{
    private ChestSO chestSO;
    private ChestView chestView;
    private ChestSlotView[] chestSlotViews;
    private ChestSlotController[] chestSlots;
    private ChestController currentSelectedChest;
    private EventService eventService;
    public ChestService(ChestSO chestSO, ChestView chestView, ChestSlotView[] chestSlotViews, EventService eventService)
    {
        this.chestSO = chestSO;
        this.chestView = chestView;
        this.chestSlotViews = chestSlotViews;
        this.eventService = eventService;
        InitializeChestSlotControllers();
        SubscribeEvents();
    }

    private void SubscribeEvents() 
    {
        eventService.SpawnChest.AddListener(CreateNewChest);
        eventService.OnChestClick.AddListener(OnChestClicked);
        eventService.OnTimeButtonClick.AddListener(OnTimerButtonClick);
        eventService.OnGemsButtonClick.AddListener(UnlockChest);
    }

    private void InitializeChestSlotControllers()
    {
        chestSlots = new ChestSlotController[chestSlotViews.Length];
        for (int i = 0; i < chestSlotViews.Length; i++)
        {
            chestSlots[i] = new ChestSlotController(chestSlotViews[i], eventService);
        }
    }

    private ChestSlotController GetEmptyChestSlot()
    {
        ChestSlotController controller = System.Array.Find(chestSlots, chestSlotController => chestSlotController.IsChestSlotEmpty());
        if (controller != null)
        {
            return controller;
        }
        else
        {
            eventService.ShowNotificationBox.Invoke("Chest Slots", "All chest slots are currently full. Please try again later!");
            return null;
        }
    }

    private void CreateNewChest()
    {
        ChestSlotController emptySlot = GetEmptyChestSlot();
        if (emptySlot != null)
        {
            ChestController newChest = new ChestController(GetRandomChestData(), chestView, emptySlot.GetChestTransformParent(), eventService);
            emptySlot.SetChestController(newChest);
        }
    }

    private ChestData GetRandomChestData() => chestSO.Chests[Random.Range(0, chestSO.Chests.Length)];

    private void OnChestClicked(ChestController chestController)
    {
        currentSelectedChest = chestController;
        switch (chestController.GetChestState())
        {
            case States.LOCKED:
                eventService.ShowLockedStateNotificationBox.Invoke(chestController.GetChestName(), string.Format("Unlock {0}.", chestController.GetChestName()));
                eventService.SetTimeButtonText.Invoke(string.Format("{0:00}:{1:00}:{2:00}", Mathf.FloorToInt(chestController.ChestModel.CurrentUnlockTime / 3600),
                    Mathf.FloorToInt((chestController.ChestModel.CurrentUnlockTime % 3600) / 60), Mathf.FloorToInt(chestController.ChestModel.CurrentUnlockTime % 60)));
                break;
            case States.UNLOCKING:
                eventService.ShowUnlockingStateNotificationBox.Invoke(chestController.GetChestName(), string.Format("Unlock {0}.", chestController.GetChestName()));
                break;
            case States.UNLOCKED:
                OnUnlockedChestClick(currentSelectedChest);
                break;

        }
        eventService.SetGemsButtonAmount.Invoke(Mathf.CeilToInt(chestController.ChestModel.CurrentUnlockTime / 600));
    }

    private void OnUnlockedChestClick(ChestController chestController)
    {
        int rewardGems = GetRandomNumber(chestController.ChestModel.Gems.x, chestController.ChestModel.Gems.y);
        int rewardCoins = GetRandomNumber(chestController.ChestModel.Coins.x, chestController.ChestModel.Coins.y);
        ChestSlotController selectedSlot = System.Array.Find<ChestSlotController>(chestSlots, slot => slot.GetChestController() == chestController);
        eventService.OnAddingCoinsAndGems.Invoke(rewardCoins, rewardGems);
        eventService.ShowRewardsPanel.Invoke(rewardCoins, rewardGems);
        selectedSlot.RemoveChest();
    }

    private void UnlockChest()
    {
        if (currentSelectedChest != null)
        {
            eventService.OnRemovingGems.Invoke(Mathf.CeilToInt(currentSelectedChest.ChestModel.CurrentUnlockTime / 600));
            currentSelectedChest.ChangeState(States.UNLOCKED);
        }
    }

    private int GetRandomNumber(int min, int max) => Random.Range(min, max);

    private void OnTimerButtonClick()
    {
        if (currentSelectedChest != null)
            eventService.EnqueueChest.Invoke(currentSelectedChest);
    }

    private void UnSubscribeEvents() 
    {
        eventService.SpawnChest.RemoveListener(CreateNewChest);
        eventService.OnChestClick.RemoveListener(OnChestClicked);
        eventService.OnTimeButtonClick.RemoveListener(OnTimerButtonClick);
        eventService.OnGemsButtonClick.RemoveListener(UnlockChest);
    }

    ~ChestService() => UnSubscribeEvents();
}