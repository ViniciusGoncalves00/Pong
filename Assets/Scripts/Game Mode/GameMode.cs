using UnityEngine;

public abstract class GameMode
{
    public Bar PlayerOne;
    public Bar PlayerTwo;
    
    public GameMode(Bar playerOne, Bar playerTwo)
    {
        PlayerOne = playerOne;
        PlayerTwo = playerTwo;
    }
    
    public abstract void Start();
    public abstract void Update();
}