using UnityEngine;

public class BaseState
{
    protected ChestStateMachine chestSM;
    public BaseState(ChestStateMachine chestSM)
    {
        this.chestSM = chestSM;
    }

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public virtual void Tick() { }
}