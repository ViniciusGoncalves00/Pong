using UnityEngine;

public class ModeVersus : GameMode
{
    private readonly ModeManager _modeManager;
    public float _increment = 10.0f;

    public ModeVersus(ModeManager modeManager, Bar playerOne, Bar playerTwo) : base(playerOne, playerTwo)
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
        }

        if (Input.GetKey(KeyCode.S))
        {
            PlayerOne.Move(-_increment);
        }

        if (Input.GetKey(KeyCode.Keypad8))
        {
            PlayerTwo.Move(_increment);
        }

        if (Input.GetKey(KeyCode.Keypad5))
        {
            PlayerTwo.Move(-_increment);
        }
    }
}