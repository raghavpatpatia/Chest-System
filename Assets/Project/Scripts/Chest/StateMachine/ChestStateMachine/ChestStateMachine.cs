using UnityEngine;

public class ChestStateMachine
{
    public Controller controller { get; private set; }
    public BaseState currentState = null;
    private LockedState lockedState;
    private UnlockingState unlockingState;
    private UnlockedState unlockedState;
    private QueuedState queuedState;

    public ChestStateMachine(Controller controller)
    {
        this.controller = controller;
        this.lockedState = new LockedState(this);
        this.unlockingState = new UnlockingState(this);
        this.unlockedState = new UnlockedState(this);
        this.queuedState = new QueuedState(this);
    }


    public void ChangeState(States state)
    {
        BaseState newState = GetChestStateFromEnum(state);
        if (currentState == newState) { return; }
        currentState?.OnStateExit();
        currentState = newState;
        controller.model.ChestState = state;
        currentState.OnStateEnter();
    }

    public BaseState GetChestStateFromEnum(States state)
    {
        switch (state)
        {
            case States.Locked:
                return lockedState;
            case States.Unlocking:
                return unlockingState;
            case States.Unlocked:
                return unlockedState;
            case States.Queued:
                return queuedState;
        }
        return null;
    }
}