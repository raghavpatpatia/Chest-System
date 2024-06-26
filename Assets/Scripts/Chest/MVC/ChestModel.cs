using UnityEngine;

public class ChestModel
{
    public ChestType ChestType { get; private set; }
    public Sprite ChestClosedImage { get; private set; }
    public Sprite ChestOpenedImage { get; private set; }
    public float UnlockTime { get; private set; }
    public float CurrentUnlockTime { get; set; }
    public Vector2Int Coins { get; private set; }
    public Vector2Int Gems { get; private set; }
    public ChestModel(ChestData chestData)
    {
        this.ChestType = chestData.ChestType;
        this.ChestClosedImage = chestData.ChestClosedImage;
        this.ChestOpenedImage = chestData.ChestOpenedImage;
        this.UnlockTime = chestData.UnlockTime;
        this.CurrentUnlockTime = UnlockTime;
        this.Coins = chestData.Coins;
        this.Gems = chestData.Gems;
    }
}