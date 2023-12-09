using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI gemText;
    [SerializeField] private TextMeshProUGUI coinText;

    [Header("Chest Slots")]
    [SerializeField] public Transform[] chestSlots;

    [Header("Button")]
    [SerializeField] private Button spawnChestButton;

    private void Start()
    {
        spawnChestButton.onClick.AddListener(CreateChest);
        Events.Instance.CoinsUpdate += UpdateCoins;
        Events.Instance.GemsUpdate += UpdateGems;
    }

    public Transform GetChestHolders()
    {
        foreach (Transform slot in chestSlots)
        {
            if (slot.childCount == 0)
            {
                return slot;
            }
        }
        return null;
    }

    public void CreateChest()
    {
        Transform chestSlot = GetChestHolders();
        if (chestSlot != null)
        {
            Events.Instance.InvokeCreateChest(chestSlot);
        }
    }

    public void UpdateCoins(int amount)
    {
        if (coinText != null)
        {
            coinText.text = amount.ToString();
        }
    }

    public void UpdateGems(int amount)
    {
        if (gemText != null)
        {
            gemText.text = amount.ToString();
        }
    }

    private void OnDestroy()
    {
        Events.Instance.CoinsUpdate -= UpdateCoins;
        Events.Instance.GemsUpdate -= UpdateGems;
    }
}