public class UnlockedState<T> : IStates where T : ChestController
{
    public ChestController ChestController { get; set; }
    private ChestStateMachine chestStateMachine;
    public UnlockedState(ChestStateMachine chestStateMachine) => this.chestStateMachine = chestStateMachine;
    public void OnStateEnter() 
    {
        ChestController.ChestView.SetChestImage(ChestController.ChestModel.ChestOpenedImage);
        ChestController.ChestView.SetChestStatus("Unlocked");
    }

    public void OnStateExit() { }

    public void Update() { }
}