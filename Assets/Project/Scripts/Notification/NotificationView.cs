using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationView : MonoBehaviour
{
    [Header("Title and Message")]
    [SerializeField] private TextMeshProUGUI notificationTitle;
    [SerializeField] private TextMeshProUGUI notificationMessage;
    [Header("Buttons")]
    [SerializeField] private Button notificationCloseButton;
    [SerializeField] private Button notificationGemsButton;
    [SerializeField] private TextMeshProUGUI notificationGemsButtonText;
    [SerializeField] private Button notificationTimeButton;
    [SerializeField] private TextMeshProUGUI notificationTimeButtonText;
    [Header("Rewards Section")]
    [SerializeField] private GameObject rewardsPanel;
    [SerializeField] private TextMeshProUGUI rewardGemsText;
    [SerializeField] private TextMeshProUGUI rewardCoinsText;
    private EventService eventService;
    private NotificationController notificationController;

    private void OnEnable()
    {
        SubscribeEvents();
        OnButtonClick();
    }

    public void Init(EventService eventService, NotificationController notificationController)
    {
        this.eventService = eventService;
        this.notificationController = notificationController;
    }
    private void SubscribeEvents()
    {
        eventService.SetGemsButtonAmount.AddListener(SetGemsButtonText);
        eventService.SetTimeButtonText.AddListener(SetTimeButtonText);
    }
    private void OnButtonClick()
    {
        notificationCloseButton.onClick.AddListener(OnNotificationCloseButtonClick);
        notificationGemsButton.onClick.AddListener(OnGemsButtonClick);
        notificationTimeButton.onClick.AddListener(OnTimeButtonClick);
    }
    // Notification
    public void SetNotificationTitle(string title) => this.notificationTitle.text = title;
    public void SetNotificationMessgae(string message) => this.notificationMessage.text = message;
    public void SetMessageBoxActive(bool status) => notificationMessage.gameObject.SetActive(status);

    // Buttons
    public void SetGemsButtonText(int amount) => this.notificationGemsButtonText.text = amount.ToString();
    public void SetTimeButtonText(string time) => this.notificationTimeButtonText.text = time;
    private void OnNotificationCloseButtonClick() => notificationController.DisableNotificationView();
    private void OnGemsButtonClick() => eventService.OnGemsButtonClick.Invoke();
    private void OnTimeButtonClick() => eventService.OnTimeButtonClick.Invoke();
    public void EnableGemsButton() => notificationGemsButton.gameObject.SetActive(true);
    public void EnableTimeButton() => notificationTimeButton.gameObject.SetActive(true);

    // Rewards
    public void SetRewardsPanelActive(bool status) => rewardsPanel.SetActive(status);
    public void SetRewardGemsText(int amount) => rewardGemsText.text = amount.ToString();
    public void SetRewardCoinsText(int amount) => rewardCoinsText.text = amount.ToString();

    public void DisableButtons()
    {
        notificationGemsButton.gameObject.SetActive(false);
        notificationTimeButton.gameObject.SetActive(false);
    }

    private void UnsubscribeEvents()
    {
        eventService.SetGemsButtonAmount.RemoveListener(SetGemsButtonText);
        eventService.SetTimeButtonText.RemoveListener(SetTimeButtonText);
        notificationCloseButton.onClick.RemoveListener(OnNotificationCloseButtonClick);
        notificationGemsButton.onClick.RemoveListener(OnGemsButtonClick);
        notificationTimeButton.onClick.RemoveListener(OnTimeButtonClick);
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }
}