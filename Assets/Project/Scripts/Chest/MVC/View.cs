using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour 
{
    public Controller controller { get; private set; }
    [SerializeField] public Image chestImage;
    [SerializeField] public Sprite openedChest;
    [SerializeField] public Sprite closedChest;

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
}