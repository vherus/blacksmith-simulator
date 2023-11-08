public abstract class BaseState
{
    public CitizenStateMachine stateMachine;
    public Citizen citizen;

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}