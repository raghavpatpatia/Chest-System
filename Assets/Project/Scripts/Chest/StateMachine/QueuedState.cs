public class QueuedState<T> : IStates where T : ChestController
{
    public ChestController ChestController { get; set; }
    private ChestStateMachine chestStateMachine;
    public QueuedState(ChestStateMachine chestStateMachine) => this.chestStateMachine = chestStateMachine;
    public void OnStateEnter() => ChestController.ChestView.SetChestStatus("Queued");

    public void OnStateExit() { }

    public void Update() { }
}