using UnityEngine;

public class ChestSlotController
{
    private ChestSlotState chestSlotState;
    private ChestController chestController;
    private ChestSlotView chestSlotView;
    private EventService eventService;
    public ChestSlotController(ChestSlotView chestSlotView, EventService eventService)
    {
        this.chestSlotView = chestSlotView;
        this.chestSlotView.SetController(this);
        this.eventService = eventService;
        SetChestSlotState(ChestSlotState.EMPTY);
        chestSlotView.SetSlotStatusText("Empty");
    }
    public void SetChestController(ChestController chestController)
    {
        this.chestController = chestController;
        SetChestSlotState(ChestSlotState.FILLED);
        chestSlotView.SetSlotStatusText("");
    }
    public ChestController GetChestController()
    {
        if (chestController != null)
            return chestController;
        return null;
    }
    public void RemoveChest()
    {
        SetChestSlotState(ChestSlotState.EMPTY);
        GetChestController().RemoveGameObject();
        chestSlotView.SetSlotStatusText("Empty");
    }
    public void SetChestSlotState(ChestSlotState chestSlotState) => this.chestSlotState = chestSlotState;
    public Transform GetChestTransformParent() => chestSlotView.transform;
    public bool IsChestSlotEmpty() => chestSlotState == ChestSlotState.EMPTY;
    public void OnChestClick(ChestController chestController) => eventService.OnChestClick.Invoke(chestController);
}