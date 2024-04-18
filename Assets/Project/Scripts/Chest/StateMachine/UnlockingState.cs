using System.Collections;
using UnityEngine;

public class UnlockingState<T> : IStates where T : ChestController
{
    public ChestController ChestController { get; set; }
    private ChestStateMachine chestStateMachine;
    public UnlockingState(ChestStateMachine chestStateMachine) => this.chestStateMachine = chestStateMachine;
    public void OnStateEnter() => ChestController.ChestView.StartCoroutine(StartTimer());

    public void OnStateExit() => ChestController.ChestView.StopCoroutine(StartTimer());

    public void Update() { }

    private IEnumerator StartTimer()
    {
        while (ChestController.ChestModel.CurrentUnlockTime > 0 && chestStateMachine.GetCurrentState() == States.UNLOCKING)
        {
            Mathf.Max(ChestController.ChestModel.CurrentUnlockTime -= Time.deltaTime, 0);
            this.ChestController.ChestView.SetChestStatus(string.Format("{0:00}:{1:00}:{2:00}", Mathf.FloorToInt(ChestController.ChestModel.CurrentUnlockTime / 3600),
            Mathf.FloorToInt((ChestController.ChestModel.CurrentUnlockTime % 3600) / 60), Mathf.FloorToInt(ChestController.ChestModel.CurrentUnlockTime % 60)));
            yield return new WaitForEndOfFrame();
        }
        ChestController.GetEventService().DequeueChest.Invoke();
        chestStateMachine.ChangeState(States.UNLOCKED);
    }
}