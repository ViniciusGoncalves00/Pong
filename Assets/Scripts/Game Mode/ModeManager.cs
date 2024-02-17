using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public ModeMachine ModeMachine { get; private set; }
    
    [SerializeField] private Ball _ball;
    [SerializeField] private Bar _playerOne;
    [SerializeField] private Bar _playerTwo;
    
    private void Awake()
    {
        ModeMachine = new ModeMachine();
        
        var gameMode = SelectedMode.GetGameMode();
        ModeMachine.ChangeMode(gameMode);
        
        ModeMachine.CurrentGameMode.SetParameters(_ball, _playerOne, _playerTwo);
    }

    private void Start()
    {
        ModeMachine.CurrentGameMode?.Start();
    }

    private void Update()
    {
        ModeMachine.CurrentGameMode?.Update();
    }
}
