public class NotificationController
{
    private NotificationView notificationView;
    private EventService eventService;
    public NotificationController(NotificationView notificationView, EventService eventService)
    {
        this.eventService = eventService;
        this.notificationView = notificationView;
        this.notificationView.Init(eventService, this);
        SubscribeEvents();
        DisableNotificationView();
    }

    private void SubscribeEvents()
    {
        eventService.ShowNotificationBox.AddListener(ShowNotificationBox);
        eventService.ShowLockedStateNotificationBox.AddListener(ShowLockedStateNotificationBox);
        eventService.ShowUnlockingStateNotificationBox.AddListener(ShowUnlockingStateNotificationBox);
        eventService.OnGemsButtonClick.AddListener(DisableNotificationView);
        eventService.OnTimeButtonClick.AddListener(DisableNotificationView);
        eventService.ShowRewardsPanel.AddListener(ShowRewardsBox);
    }

    private void ShowNotificationBox(string title, string message)
    {
        notificationView.gameObject.SetActive(true);
        notificationView.SetMessageBoxActive(true);
        notificationView.SetNotificationTitle(title);
        notificationView.SetNotificationMessgae(message);
        notificationView.SetRewardsPanelActive(false);
        notificationView.DisableButtons();
    }

    private void ShowLockedStateNotificationBox(string title, string message)
    {
        notificationView.DisableButtons();
        notificationView.gameObject.SetActive(true);
        notificationView.SetMessageBoxActive(true);
        notificationView.SetNotificationTitle(title);
        notificationView.SetNotificationMessgae(message);
        notificationView.SetRewardsPanelActive(false);
        notificationView.EnableGemsButton();
        notificationView.EnableTimeButton();
    }

    private void ShowUnlockingStateNotificationBox(string title, string message) 
    {
        notificationView.DisableButtons();
        notificationView.gameObject.SetActive(true);
        notificationView.SetMessageBoxActive(true);
        notificationView.SetNotificationTitle(title);
        notificationView.SetNotificationMessgae(message);
        notificationView.SetRewardsPanelActive(false);
        notificationView.EnableGemsButton();
    }

    private void ShowRewardsBox(int coinsAmount, int gemsAmount)
    {
        notificationView.gameObject.SetActive(true);
        notificationView.SetRewardsPanelActive(true);
        notificationView.SetMessageBoxActive(false);
        notificationView.SetNotificationTitle("You Received");
        notificationView.SetRewardCoinsText(coinsAmount);
        notificationView.SetRewardGemsText(gemsAmount);
        notificationView.DisableButtons();
    }

    public void DisableNotificationView() => notificationView.gameObject.SetActive(false);

    private void UnsubscribeEvents()
    {
        eventService.ShowNotificationBox.RemoveListener(ShowNotificationBox);
        eventService.ShowLockedStateNotificationBox.RemoveListener(ShowLockedStateNotificationBox);
        eventService.ShowUnlockingStateNotificationBox.RemoveListener(ShowUnlockingStateNotificationBox);
        eventService.OnGemsButtonClick.RemoveListener(DisableNotificationView);
        eventService.OnTimeButtonClick.RemoveListener(DisableNotificationView);
        eventService.ShowRewardsPanel.RemoveListener(ShowRewardsBox);
    }

    ~NotificationController()
    {
        UnsubscribeEvents();
    }
}