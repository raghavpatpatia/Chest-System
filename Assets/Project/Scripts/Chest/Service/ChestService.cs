using System.Collections.Generic;
using UnityEngine;

public class ChestService : Singleton<ChestService>
{
    [SerializeField] private ChestScriptableObjectList chestList;
    private Controller chestController;
    private List<Controller> chestControllerList = new List<Controller>();
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        Events.Instance.CreateChest += GenerateRandomChest;
    }

    public void GenerateRandomChest(Transform transform)
    {
        if (chestControllerList.Count <= 4)
        {
            chestController = new Controller(chestList.list[Random.Range(0, chestList.list.Length)], transform);
            chestControllerList.Add(chestController);
        }
    }

    public void AddCurrency(int coins, int gems)
    {
        CurrencyManager.Instance.AddCoins(coins);
        CurrencyManager.Instance.AddGems(gems);
    }

    public void DestroyChest(Controller controller)
    {
        chestControllerList.Remove(controller);
        Destroy(controller.view.gameObject);
    }

    private void OnDestroy()
    {
        Events.Instance.CreateChest -= GenerateRandomChest;
    }

}