using UnityEngine;

public class ModeSolo : GameMode
{
    private readonly ModeManager _modeManager;
    public float _increment = 10.0f;

    public ModeSolo(ModeManager modeManager, Bar playerOne, Bar playerTwo) : base(playerOne, playerTwo)
    {
        _modeManager = modeManager;
    }

    public override void Start()
    {
    }

    public override void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PlayerOne.Move(_increment);
            PlayerTwo.Move(_increment);
        }

        if (Input.GetKey(KeyCode.S))
        {
            PlayerOne.Move(-_increment);
            PlayerTwo.Move(-_increment);
        }
    }
}