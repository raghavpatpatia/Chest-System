public class LockState<T> : IStates where T : ChestController
{
    private ChestStateMachine chestStateMachine;
    public LockState(ChestStateMachine chestStateMachine) => this.chestStateMachine = chestStateMachine;
    public ChestController ChestController { get ; set ; }

    public void OnStateEnter() 
    {
        ChestController.ChestView.SetChestStatus("Locked");
        ChestController.ChestView.SetChestImage(ChestController.ChestModel.ChestClosedImage);
        ChestController.ChestView.SetChestName(ChestController.GetChestName());
    }

    public void OnStateExit() { }

    public void Update() { }
}