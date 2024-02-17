public abstract class GameMode
{
    protected Bar PlayerOne;
    protected Bar PlayerTwo;

    protected Ball Ball;

    protected const float Velocity = 20.0f;

    public void SetParameters(Ball ball, Bar playerOne, Bar playerTwo)
    {
        Ball = ball;
        PlayerOne = playerOne;
        PlayerTwo = playerTwo;
    }
    
    public abstract void Start();
    public abstract void Update();
}