public class ChestSlotManager : Singleton<ChestSlotManager>
{
    public ChestSlot[] chestSlots;

    public void SetSlotState(ChestSlot chestSlot, ChestSlotState state)
    {
        chestSlot.slotState = state;
    }
}
