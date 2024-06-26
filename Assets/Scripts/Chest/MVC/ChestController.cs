using UnityEngine;

public class ChestController
{
    public readonly ChestModel ChestModel;
    public readonly ChestView ChestView;
    private EventService eventService;
    private ChestStateMachine chestStateMachine;
    public ChestController(ChestData chestData, ChestView chestView, Transform parentTransform, EventService eventService)
    {
        this.ChestModel = new ChestModel(chestData);
        this.ChestView = GameObject.Instantiate<ChestView>(chestView, parentTransform);
        this.eventService = eventService;
        SetChestStateMachine();
        ChangeState(States.LOCKED);
    }
    private void SetChestStateMachine() => chestStateMachine = new ChestStateMachine(this);
    public void ChangeState(States state) => chestStateMachine.ChangeState(state);
    public EventService GetEventService() => eventService;
    public States GetChestState() => chestStateMachine.GetCurrentState();
    public string GetChestName()
    {
        string name;
        switch (this.ChestModel.ChestType)
        {
            case ChestType.COMMON:
                name = "Common Chest";
                break;
            case ChestType.RARE:
                name = "Rare Chest";
                break;
            case ChestType.EPIC:
                name = "Epic Chest";
                break;
            case ChestType.LEGENDARY:
                name = "Legendary Chest";
                break;
            default:
                name = "";
                break;
        }
        return name;
    }
    public void RemoveGameObject() => GameObject.Destroy(ChestView.gameObject);
}