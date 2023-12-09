using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour 
{
    public Controller controller { get; private set; }
    [SerializeField] public Image chestImage;
    [SerializeField] private Sprite openedChest;
    [SerializeField] private Sprite closedChest;

    private Button changeState;

    private void Start()
    {
        changeState = GetComponent<Button>();
        changeState.onClick.AddListener(OpenedChest);
        SetChestImage(closedChest);
    }

    public void SetController(Controller controller)
    {
        this.controller = controller;
    }

    public void SetChestImage(Sprite sprite)
    {
        controller.SetChestImage(sprite);
    }

    private void OpenedChest()
    {
        SetChestImage(openedChest);
        controller.OpenedChest();
    }
}