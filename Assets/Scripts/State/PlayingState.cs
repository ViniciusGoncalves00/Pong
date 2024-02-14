public class PlayingState : GameState
{
    public virtual void ChangeState(StateMachine gameStateMachine)
    {
        SetContext(gameStateMachine);
    }
    public override void SetState()
    {
        throw new System.NotImplementedException();
    }
}