using UnityEngine;

public class SoloMode : GameMode
{
    public override void Start()
    {
    }

    public override void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PlayerOne.Move(Velocity);
            PlayerTwo.Move(Velocity);
        }

        if (Input.GetKey(KeyCode.S))
        {
            PlayerOne.Move(-Velocity);
            PlayerTwo.Move(-Velocity);
        }
    }
}