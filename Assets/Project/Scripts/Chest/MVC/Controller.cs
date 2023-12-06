using UnityEngine;

public class Controller
{
    public Model model { get; private set; }
    public View view { get; private set; }
    public Controller(ChestScriptableObject chestScriptableObject)
    {
        this.model = new Model(chestScriptableObject, this);
        this.view = GameObject.Instantiate<View>(chestScriptableObject.chestView);
        this.view.SetController(this);
    }
}