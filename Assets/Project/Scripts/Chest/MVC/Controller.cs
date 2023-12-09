using UnityEngine;
using UnityEngine.UI;
public class Controller
{
    public Model model { get; private set; }
    public View view { get; private set; }
    public Controller(ChestScriptableObject chestScriptableObject, Transform transform)
    {
        this.model = new Model(chestScriptableObject, this);
        this.view = GameObject.Instantiate<View>(chestScriptableObject.chestView);
        this.view.SetController(this);

        view.transform.SetParent(transform, false);
    }

    public void SetChestImage(Sprite sprite)
    {
        view.chestImage.sprite = sprite;
    }

    public void OpenedChest()
    {
        int coins = Random.Range(model.minCoins, model.maxCoins);
        int gems = Random.Range(model.minGems, model.maxGems);
        ChestService.Instance.AddCurrency(coins, gems);
        ChestService.Instance.DestroyChest(this);
    }
}