using UnityEngine;

[CreateAssetMenu(fileName = "ChestScriptableObject", menuName = "ScriptableObjects/ChestScriptableObject")]
public class ChestScriptableObject : ScriptableObject
{
    [Header("View")]
    public View chestView;
    [Header("ChestType")]
    public ChestType chestType;
    [Header("Coins")]
    public int minCoins;
    public int maxCoins;
    [Header("Gems")]
    public int minGems;
    public int maxGems;
    [Header("Time")]
    public float time;
}