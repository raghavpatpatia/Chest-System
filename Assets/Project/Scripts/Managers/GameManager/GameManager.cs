using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
    [Header("Chest Slots")]
    [SerializeField] public Transform[] chestSlots;

    [Header("Button")]
    [SerializeField] private Button spawnChestButton;

    private List<Transform> visitedSlots = new List<Transform>();
    private Transform chestSlot;

    private void Start()
    {
        spawnChestButton.onClick.AddListener(CreateChest);
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

}