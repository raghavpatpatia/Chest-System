using UnityEngine;

[CreateAssetMenu(fileName = "ChestScriptableObject", menuName = "ScriptableObjects/ChestScriptableObject")]
public class ChestScriptableObject : ScriptableObject
{
    public Vector2Int Chest_Coins_Range;
    public Vector2Int Chest_Gems_Range;
    public float Unlock_Time;
    public float Gems_To_Unlock;
    public float Max_Unlock_Time;
    public float Max_Gems_To_Unlock;
    public View ChestView;
    public ChestType Chest_Type;
}