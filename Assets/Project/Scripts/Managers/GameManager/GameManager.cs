using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
    [Header("UI Text")]
    [SerializeField] private TextMeshProUGUI gemText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI unlockChestTimerButtonText;
    [SerializeField] private TextMeshProUGUI unlockWithGemsButtonText;
    [SerializeField] private TextMeshProUGUI rewardGemText;
    [SerializeField] private TextMeshProUGUI rewardCoinText;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private TextMeshProUGUI unlockWithGemsPanelButtonText;

    [Header("UI Panel")]
    [SerializeField] private GameObject unlockChestPanel;
    [SerializeField] private GameObject rewardsPanel;
    [SerializeField] private GameObject notificationsPanel;
    [SerializeField] private GameObject unlockwitGemsPanel;

    [Header("Button")]
    [SerializeField] private Button spawnChestButton;
    [SerializeField] private Button unlockChestTimerButton;
    [SerializeField] private Button unlockWithGemsButton;
    [SerializeField] private Button acceptRewardButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button goBackButton;
    [SerializeField] private Button unlockWithGemsPanelButton;

    private Controller currentChest;

    private void OnEnable()
    {
        Events.Instance.CoinsUpdate += UpdateCoins;
        Events.Instance.GemsUpdate += UpdateGems;
        Events.Instance.OnQueueFull += OnQueueFull;
        Events.Instance.OnChestClicked += ChestClicked;
        Events.Instance.OnSlotsFull += SlotsFull;
    }

    private void Start()
    {
        spawnChestButton.onClick.AddListener(ChestService.Instance.SpawnChest);
        unlockChestTimerButton.onClick.AddListener(StartTimer);
        unlockWithGemsButton.onClick.AddListener(UnlockChest);
        acceptRewardButton.onClick.AddListener(DisableRewardsPanel);
        closeButton.onClick.AddListener(DisableNotificationsPanel);
        goBackButton.onClick.AddListener(DisableUnlockChestWithGemsPanel);
        unlockWithGemsPanelButton.onClick.AddListener(UnlockChest);
    }

    // Chest Functions
    private void OnQueueFull()
    {
        SetMessageText("Queue is full! Try again later..");
        EnableNotificationsPanel();
    }
    private void SlotsFull()
    {
        SetMessageText("Slots are full! Unlock some chest first.");
        EnableNotificationsPanel();
    }

    // Currency Updation
    private void UpdateCoins(int amount)
    {
        if (coinText != null)
        {
            coinText.text = amount.ToString();
        }
    }
    private void UpdateGems(int amount)
    {
        if (gemText != null)
        {
            gemText.text = amount.ToString();
        }
    }

    // UI
        // Enable Panels
    private void EnableUnlockChestPanel()
    {
        unlockChestPanel.SetActive(true);
    }
    private void EnableRewardsPanel()
    {
        rewardsPanel.SetActive(true);
    }
    private void EnableNotificationsPanel()
    {
        notificationsPanel.SetActive(true);
    }
    private void EnableUnlockChestWithGemsPanel()
    {
        unlockwitGemsPanel.SetActive(true);
    }
        // Disable Panels
    private void DisableUnlockChestPanel()
    {
        unlockChestPanel.SetActive(false);
    }
    private void DisableRewardsPanel()
    {
        rewardsPanel.SetActive(false);
    }
    private void DisableNotificationsPanel()
    {
        notificationsPanel.SetActive(false);
    }
    private void DisableUnlockChestWithGemsPanel()
    {
        unlockwitGemsPanel.SetActive(false);
    }
        // Setting Text
    private void SetUnlockChestTimerButtonText(string text)
    {
        unlockChestTimerButtonText.text = text;
    }
    private void SetUnlockWithGemsButtonText(string text)
    {
        unlockWithGemsButtonText.text = text;
    }
    private void SetRewardGemText(string text)
    {
        rewardGemText.text = text;
    }
    private void SetRewardCoinText(string text)
    {
        rewardCoinText.text = text;
    }
    private void SetMessageText(string text)
    {
        messageText.text = text;
    }
    private void SetUnlockWithGemsPanelButtonText(string text)
    {
        unlockWithGemsPanelButtonText.text = text;
    } 

    // Button Functions
    private void StartTimer()
    {
        if (currentChest != null)
        {
            DisableUnlockChestPanel();
            ChestQueueServiceManager.Instance.EnQueueChest(currentChest);
        }
        else
        {
            Debug.LogError("currentChest is null!");
        }
    }
    private void UnlockChest()
    {
        if (currentChest != null)
        {
            int gemCount = (int)currentChest.model.GEMS_TO_UNLOCK; 
            if (CurrencyManager.Instance.totalGems >= gemCount)
            {
                CurrencyManager.Instance.RemoveGems(gemCount);
                currentChest.stateMachine.ChangeState(States.Unlocked);
                DisableUnlockChestPanel();
                DisableUnlockChestWithGemsPanel();
            }
            else
            {
                SetMessageText("Not enough gems!");
                EnableNotificationsPanel();
            }
        }
        else
        {
            Debug.LogError("currentChest is null!");
        }
    }
    private void ShowChestRewards(int coins, int Gems)
    {
        SetRewardCoinText(coins.ToString());
        SetRewardGemText(Gems.ToString());
        EnableRewardsPanel();
    }
    private void ChestClicked(Controller controller)
    {
        States chestState = controller.model.ChestState;
        currentChest = controller;
        currentChest.SetStateMachine(currentChest);
        switch (chestState)
        {
            case States.Locked:
                LockedChestPopUp(currentChest);
                break;
            case States.Unlocking:
                ShowUnlockWithGemsScreen();
                break;
            case States.Unlocked:
                GetChestRewards();
                break;
        }
    }
    private void LockedChestPopUp(Controller controller)
    {
        int hours = Mathf.FloorToInt(controller.model.MAX_UNLOCK_TIME / 3600);
        int minutes = Mathf.FloorToInt((controller.model.MAX_UNLOCK_TIME % 3600) / 60);
        int seconds = Mathf.FloorToInt(controller.model.MAX_UNLOCK_TIME % 60);
        SetUnlockChestTimerButtonText(string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds));
        SetUnlockWithGemsButtonText(controller.model.MAX_GEMS_TO_UNLOCK.ToString());
        EnableUnlockChestPanel();
    }
    private void GetChestRewards()
    {
        int randomCoins = UnityEngine.Random.Range(currentChest.model.COINS_RANGE.x, currentChest.model.COINS_RANGE.y);
        int randomGems = UnityEngine.Random.Range(currentChest.model.GEMS_RANGE.x, currentChest.model.GEMS_RANGE.y);
        ChestSlot slot = Array.Find(ChestSlotManager.Instance.chestSlots, i => i.controller == currentChest);

        ChestService.Instance.DestroyChest(currentChest);

        ChestSlotManager.Instance.SetSlotState(slot, ChestSlotState.Empty);
        slot.TimerText.text = "";

        ShowChestRewards(randomCoins, randomGems);
        CurrencyManager.Instance.AddCurrency(randomCoins, randomGems);
    }
    private void ShowUnlockWithGemsScreen()
    {
        SetUnlockWithGemsPanelButtonText(currentChest.model.GEMS_TO_UNLOCK.ToString());
        EnableUnlockChestWithGemsPanel();
    }


    private void OnDestroy()
    {
        Events.Instance.CoinsUpdate -= UpdateCoins;
        Events.Instance.GemsUpdate -= UpdateGems;
        Events.Instance.OnQueueFull -= OnQueueFull;
        Events.Instance.OnSlotsFull -= SlotsFull;
        Events.Instance.OnChestClicked -= ChestClicked;
    }
}