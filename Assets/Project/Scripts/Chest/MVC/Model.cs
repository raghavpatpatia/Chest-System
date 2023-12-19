using UnityEngine;

public class Model
{
    public Controller controller { get; private set; }
    public Vector2Int COINS_RANGE { get; }
    public Vector2Int GEMS_RANGE { get; }
    public float UNLOCK_TIME { get; set; }
    public float GEMS_TO_UNLOCK { get; set; }
    public float MAX_UNLOCK_TIME { get; }
    public float MAX_GEMS_TO_UNLOCK { get; }
    public View ChestView { get; }
    public ChestType ChestType { get; }
    public States ChestState { get; set; }

    public Model(ChestScriptableObject chestScriptableObject)
    {
        this.controller = controller;
        COINS_RANGE = chestScriptableObject.Chest_Coins_Range;
        GEMS_RANGE = chestScriptableObject.Chest_Gems_Range;
        UNLOCK_TIME = chestScriptableObject.Unlock_Time;
        MAX_UNLOCK_TIME = chestScriptableObject.Max_Unlock_Time;
        MAX_GEMS_TO_UNLOCK = chestScriptableObject.Max_Gems_To_Unlock;
        ChestType = chestScriptableObject.Chest_Type;
        ChestView = chestScriptableObject.ChestView;
        ChestState = States.Locked;
    }

    public void SetController(Controller controller)
    {
        this.controller = controller;
    }
}