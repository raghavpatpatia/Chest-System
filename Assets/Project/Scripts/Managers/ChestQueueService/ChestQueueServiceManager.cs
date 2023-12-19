using System.Collections.Generic;
using UnityEngine;

public class ChestQueueServiceManager : Singleton<ChestQueueServiceManager>
{
    [SerializeField] private int queueCount;
    private Queue<Controller> controllerQueue;
    private Controller currentChest = null;

    public ChestQueueServiceManager()
    {
        controllerQueue = new Queue<Controller>();
    }

    public int GetQueueCount() { return controllerQueue.Count; }

    public void EnQueueChest(Controller controller)
    {
        if (QueueHasSpace())
        {
            controller.stateMachine.ChangeState(States.Queued);
            controllerQueue.Enqueue(controller);

            if (currentChest == null)
                DeQueueChest();
        }
        else
        {
            Events.Instance.InvokeOnQueueFull();
        }
    }

    public void DeQueueChest()
    {
        if (GetQueueCount() > 0)
        {
            Controller controller = controllerQueue.Dequeue();
            currentChest = controller;
            currentChest.stateMachine.ChangeState(States.Unlocking);
        }
        else
        {
            currentChest = null;
        }
    }

    public bool QueueHasSpace()
    {
        return controllerQueue.Count < queueCount;
    }
}