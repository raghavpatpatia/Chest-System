using UnityEngine;

public class View : MonoBehaviour 
{
    public Controller controller { get; private set; }
    public void SetController(Controller controller)
    {
        this.controller = controller;
    }
}