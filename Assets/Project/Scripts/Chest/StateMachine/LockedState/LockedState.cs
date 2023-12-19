using System;
using UnityEngine;

public class LockedState : BaseState
{
    public LockedState(ChestStateMachine stateMachine) : base(stateMachine) { }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        SetTimerText();
    }

    private void SetTimerText()
    {
        Controller chest = chestSM.controller;
        ChestSlot slot = Array.Find(ChestSlotManager.Instance.chestSlots, i => i.controller == chest);

        if (slot != null)
        {
            slot.TimerText.text = "Locked";
        }
        else
        {
            Debug.LogError("ChestSlot not found for the given controller.");
        }
    }

}