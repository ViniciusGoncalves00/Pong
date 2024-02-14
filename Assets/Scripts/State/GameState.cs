public abstract class GameState
{
    protected StateMachine StateMachine;

    public void SetContext(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public abstract void SetState();

    public virtual void EnterState() { }
    public virtual void ExitState() { }
}