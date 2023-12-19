using UnityEngine;

public class ChestService : Singleton<ChestService>
{
    [SerializeField] private ChestScriptableObjectList chestList;
    protected override void Awake()
    {
        base.Awake();
    }

    public void DestroyChest(Controller controller)
    {
        Destroy(controller.view.gameObject);
    }

    public void SpawnChest()
    {
        for (int i = 0; i < ChestSlotManager.Instance.chestSlots.Length; i++)
        {
            ChestSlot slot = ChestSlotManager.Instance.chestSlots[i];
            if (slot.slotState == ChestSlotState.Empty)
            {
                ChestSlotManager.Instance.SetSlotState(slot, ChestSlotState.Filled);
                GenerateRandomChest(slot);
                break;
            }
            if (i == ChestSlotManager.Instance.chestSlots.Length - 1)
            {
                Events.Instance.InvokeSlotsFull();
            }
        }
    }

    private void GenerateRandomChest(ChestSlot slot)
    {
        int randomRange = Random.Range(0, chestList.list.Length);
        ChestScriptableObject obj = chestList.list[randomRange];

        Model model = new Model(obj);
        View view = GameObject.Instantiate<View>(model.ChestView, slot.slot.transform);
        view.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;

        Controller newChest = new Controller(model, view);
        view.SetController(newChest);
        model.SetController(newChest);
        slot.controller = newChest;
        newChest.SetStateMachine(newChest);
        newChest.stateMachine.ChangeState(States.Locked);
    }

}