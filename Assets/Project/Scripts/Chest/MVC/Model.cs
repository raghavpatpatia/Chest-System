public class Model
{
    public Controller controller { get; private set; }
    public ChestType chestType { get; private set; }
    public int minCoins { get; private set; }
    public int maxCoins { get; private set; }
    public int minGems { get; private set; }
    public int maxGems { get; private set; }
    public float time { get; private set; }

    public Model(ChestScriptableObject chestScriptableObject, Controller controller)
    {
        this.controller = controller;
        this.chestType = chestScriptableObject.chestType;
        this.minCoins = chestScriptableObject.minCoins;
        this.maxCoins = chestScriptableObject.maxCoins;
        this.minGems = chestScriptableObject.minGems;
        this.maxGems = chestScriptableObject.maxGems;
        this.time = chestScriptableObject.time;
    }
}