using System.Collections.Generic;

public class ChestStateMachine : GenericStateMachine<ChestController>
{
    public ChestStateMachine(ChestController controller) : base(controller)
    {
        this.controller = controller;
        CreateStates();
        SetController();
    }

    private void CreateStates()
    {
        states.Add(States.LOCKED, new LockState<ChestController>(this));
        states.Add(States.QUEUED, new QueuedState<ChestController>(this));
        states.Add(States.UNLOCKING, new UnlockingState<ChestController>(this));
        states.Add(States.UNLOCKED, new UnlockedState<ChestController>(this));
    }

    public States GetCurrentState()
    {
        foreach (KeyValuePair<States, IStates> key in states)
        {
            if (EqualityComparer<IStates>.Default.Equals(key.Value, currentState))
            {
                return key.Key;
            }
        }
        throw new KeyNotFoundException("The specified value was not found in the dictionary.");
    }
}