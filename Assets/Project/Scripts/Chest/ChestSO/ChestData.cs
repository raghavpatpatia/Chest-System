using UnityEngine;

[System.Serializable]
public class ChestData
{
    [Header("Chest Type")]
    public ChestType ChestType;
    [Header("Chest Images")]
    public Sprite ChestClosedImage;
    public Sprite ChestOpenedImage;
    [Header("Chest Unlock Time")]
    public float UnlockTime;
    [Header("Chest Rewards")]
    public Vector2Int Coins;
    public Vector2Int Gems;
}