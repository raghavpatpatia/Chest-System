using UnityEngine;
using UnityEngine.UI;
public class Controller
{
    public Model model { get; private set; }
    public View view { get; private set; }
    public ChestStateMachine stateMachine { get; private set; }
    public Controller(Model model, View view)
    {
        this.model = model;
        this.view = view;
    }
    public void SetStateMachine(Controller controller)
    {
        stateMachine = new ChestStateMachine(controller);
    }
    public void SetChestImage(Sprite sprite)
    {
        view.chestImage.sprite = sprite;
    }
    public void ChangeUnlockTimer(float time)
    {
        model.UNLOCK_TIME = Mathf.Max(model.UNLOCK_TIME - time, 0);
        model.GEMS_TO_UNLOCK = Mathf.Ceil((model.UNLOCK_TIME / model.MAX_UNLOCK_TIME) * model.MAX_GEMS_TO_UNLOCK);
    }
}