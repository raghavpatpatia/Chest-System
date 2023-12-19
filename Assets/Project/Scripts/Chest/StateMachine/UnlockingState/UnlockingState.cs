using System;
using System.Collections;
using UnityEngine;
public class UnlockingState : BaseState
{
    public UnlockingState(ChestStateMachine chestSM) : base(chestSM) { }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        chestSM.controller.view.StartCoroutine(StartTimer());
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        chestSM.controller.view.StopCoroutine(StartTimer());
    }
    private IEnumerator StartTimer()
    {
        Controller controller = chestSM.controller;
        Model model = controller.model;
        ChestSlot slot = Array.Find(ChestSlotManager.Instance.chestSlots, i => i.controller == controller);
        while (model.UNLOCK_TIME > 0 && model.ChestState == States.Unlocking)
        {
            controller.ChangeUnlockTimer(Time.deltaTime);
            slot.TimerText.text = GetTimerText(model.UNLOCK_TIME);
            yield return new WaitForEndOfFrame();
        }
        chestSM.ChangeState(States.Unlocked);
        ChestQueueServiceManager.Instance.DeQueueChest();
    }

    private string GetTimerText(float UNLOCK_TIME)
    {
        int hours = Mathf.FloorToInt(UNLOCK_TIME / 3600);
        int minutes = Mathf.FloorToInt((UNLOCK_TIME % 3600) / 60);
        int seconds = Mathf.FloorToInt(UNLOCK_TIME % 60);

        return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}