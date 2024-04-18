using System.Collections.Generic;

public class GenericStateMachine<T> where T : ChestController
{
    protected T controller;
    protected IStates currentState;
    protected Dictionary<States, IStates> states = new Dictionary<States, IStates>();
    public GenericStateMachine(T controller) => this.controller = controller;
    public void Update() => currentState.Update();
    protected void ChangeState(IStates newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState?.OnStateEnter();
    }
    public void ChangeState(States newState) => ChangeState(states[newState]);
    protected void SetController()
    {
        foreach(IStates state in states.Values)
        {
            state.ChestController = controller;
        }
    }
}