using System;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public ModeMachine ModeMachine { get; private set; }
    public NoMode NoMode { get; private set; }
    public ModeSolo ModeSolo { get; private set; }
    public ModeVersus ModeVersus { get; private set; }
    
    private Bar _playerOne;
    private Bar _playerTwo;
    
    private void Awake()
    {
        ModeMachine = new ModeMachine();
        NoMode = new NoMode(null, null);
        ModeSolo = new ModeSolo(this, _playerOne, _playerOne);
        ModeVersus = new ModeVersus(this, _playerOne, _playerTwo);
    }

    private void Start()
    {
        ModeMachine.CurrentGameMode?.Start();
    }

    private void Update()
    {
        FindObjectsOfType();
        
        ModeMachine.CurrentGameMode?.Update();
    }

    public void FindObjectsOfType()
    {
        var bars = FindObjectsOfType<Bar>();
        if (bars.Length == 0)
            return;

        _playerOne = bars[0];
        _playerTwo = bars[1];

        ModeMachine.CurrentGameMode.PlayerOne = _playerOne;
        ModeMachine.CurrentGameMode.PlayerTwo = _playerTwo;
    }
}
