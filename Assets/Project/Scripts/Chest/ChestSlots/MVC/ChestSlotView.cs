using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChestSlotView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI chestSlotStatus;
    private ChestSlotController controller;
    public void SetController(ChestSlotController controller) => this.controller = controller;
    public void SetSlotStatusText(string text) => chestSlotStatus.text = text;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!controller.IsChestSlotEmpty())
            controller.OnChestClick(controller.GetChestController());
    }
}