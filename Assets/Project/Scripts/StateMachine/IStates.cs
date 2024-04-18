public interface IStates
{
    public ChestController ChestController { get; set; }
    public void OnStateEnter();
    public void Update();
    public void OnStateExit();
}