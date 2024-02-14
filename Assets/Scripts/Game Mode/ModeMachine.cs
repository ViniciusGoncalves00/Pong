using UnityEngine;

public class ModeMachine
{
    public GameMode CurrentGameMode { get; private set; }
    public GameMode PreviousGameMode { get; private set; }
    
    public void ChangeMode(GameMode newMode)
    {
        PreviousGameMode = CurrentGameMode;
        CurrentGameMode = newMode;
        Debug.Log(CurrentGameMode);
    }
}