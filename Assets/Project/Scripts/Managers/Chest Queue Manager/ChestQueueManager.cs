using System.Collections.Generic;

public class ChestQueueManager
{
    private int queueCount;
    private Queue<ChestController> controllerQueue;
    private ChestController currentChest = null;
    private EventService eventService;
    public ChestQueueManager(int queueCount, EventService eventService)
    {
        this.queueCount = queueCount;
        this.eventService = eventService;
        controllerQueue = new Queue<ChestController>();
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        eventService.EnqueueChest.AddListener(EnqueueChest);
        eventService.DequeueChest.AddListener(DequeueChest);
    }

    private int GetQueueCount() { return controllerQueue.Count; }

    private void EnqueueChest(ChestController controller)
    {
        if (QueueHasSpace())
        {
            controller.ChangeState(States.QUEUED);
            controllerQueue.Enqueue(controller);

            if (currentChest == null)
                DequeueChest();
        }
        else
        {
            eventService.ShowNotificationBox.Invoke("Chest Queue", "Chest queue if full. Please try again later!");
        }
    }

    private void DequeueChest()
    {
        if (GetQueueCount() > 0)
        {
            ChestController controller = controllerQueue.Dequeue();
            currentChest = controller;
            currentChest.ChangeState(States.UNLOCKING);
        }
        else
        {
            currentChest = null;
        }
    }

    private bool QueueHasSpace()
    {
        return GetQueueCount() < queueCount;
    }

    private void UnsubscribeEvents()
    {
        eventService.EnqueueChest.RemoveListener(EnqueueChest);
        eventService.DequeueChest.RemoveListener(DequeueChest);
    }

    ~ChestQueueManager() => UnsubscribeEvents();
}