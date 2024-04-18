using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Money System")]
    [SerializeField] private int startingCoins;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private int startingGems;
    [SerializeField] private TextMeshProUGUI gemsText;
    [Header("Notification Box")]
    [SerializeField] private NotificationView notificationView;
    [Header("Chest")]
    [SerializeField] private ChestSO chestSO;
    [SerializeField] private ChestView chestView;
    [SerializeField] private Button spawnChestButton;
    [Header("Chest Slots")]
    [SerializeField] private ChestSlotView[] chestSlots;
    [Header("Chest Queue")]
    [SerializeField] private int queueCount;

    private EventService eventService;
    private NotificationController notificationController;
    private MoneyController moneyController;
    private ChestService chestService;
    private ChestQueueManager chestQueue;
    private void Start()
    {
        Initialize();
        spawnChestButton.onClick.AddListener(OnSpawnChestButtonClick);
    }

    private void Initialize()
    {
        eventService = new EventService();
        moneyController = new MoneyController(startingCoins, startingGems, moneyText, gemsText, eventService);
        notificationController = new NotificationController(notificationView, eventService);
        chestService = new ChestService(chestSO, chestView, chestSlots, eventService);
        chestQueue = new ChestQueueManager(queueCount, eventService);
    }

    private void OnSpawnChestButtonClick() => eventService.SpawnChest.Invoke();
}
