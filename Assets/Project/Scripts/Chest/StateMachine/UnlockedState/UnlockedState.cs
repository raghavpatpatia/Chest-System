using System;
public class UnlockedState : BaseState
{
    public UnlockedState(ChestStateMachine chestSM) : base(chestSM) { }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        SetTimerText();
    }

    private void SetTimerText()
    {
        Controller controller = chestSM.controller;
        controller.SetChestImage(controller.view.openedChest);
        ChestSlot slot = Array.Find(ChestSlotManager.Instance.chestSlots, i => i.controller == controller);
        slot.TimerText.text = "Unlocked";
    }
}