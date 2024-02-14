public class StateMachine
{
    public GameState GameState { get; private set; }

    public StateMachine(GameState gameState)
    {
        GameState?.ExitState();
        GameState = gameState;
        GameState?.EnterState();
    }

    public void Request()
    {
        
    }
}
