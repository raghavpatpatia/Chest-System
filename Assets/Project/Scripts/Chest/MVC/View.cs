using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class View : MonoBehaviour, IPointerClickHandler
{
    public Controller controller { get; private set; }
    [SerializeField] public Image chestImage;
    [SerializeField] public Sprite openedChest;
    [SerializeField] private Sprite closedChest;

    private void Start()
    {
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

    public void OnPointerClick(PointerEventData eventData)
    {
        Events.Instance.InvokeOnChestClicked(controller);
    }
}