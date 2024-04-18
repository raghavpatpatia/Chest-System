using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    [SerializeField] private Image chestImage;
    [SerializeField] private TextMeshProUGUI chestStatus;
    [SerializeField] private TextMeshProUGUI chestName;
    private ChestController chestController;
    public void SetChestController(ChestController chestController) => this.chestController = chestController;
    public void SetChestImage(Sprite newImage) => chestImage.sprite = newImage;
    public void SetChestStatus(string status) => chestStatus.text = status;
    public void SetChestName(string name) => chestName.text = name;
}