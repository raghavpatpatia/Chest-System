using System;

public class QueuedState : BaseState
{
    public QueuedState(ChestStateMachine chestSM) : base(chestSM) { }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        SetTimerText();
    }

    private void SetTimerText()
    {
        Controller controller = chestSM.controller;
        ChestSlot slot = Array.Find(ChestSlotManager.Instance.chestSlots, i => i.controller == controller);
        slot.TimerText.text = "Queued";
    }
}