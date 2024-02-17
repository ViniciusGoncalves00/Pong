using UnityEngine;

public class VersusMode : GameMode
{
    public override void Start()
    {
    }

    public override void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PlayerOne.Move(Velocity);
        }

        if (Input.GetKey(KeyCode.S))
        {
            PlayerOne.Move(-Velocity);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            PlayerTwo.Move(Velocity);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            PlayerTwo.Move(-Velocity);
        }
    }
}