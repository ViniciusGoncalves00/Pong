using UnityEngine;

public class IAMode : GameMode
{
    private Vector2 _barCenter = new Vector2(15, 0);
    
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

        if (BallIsComingToMe())
        {
            TryDefend();
        }

        else
        {
            Move(_barCenter);
        }
    }

    private bool BallIsComingToMe()
    {
        return Ball.Direction.x > 0;
    }

    private void TryDefend()
    {
        var ballPosition = Ball.transform.position;

        PlayerTwo.IAMove(ballPosition, Velocity);
    }

    private void Move(Vector2 target)
    {
        var position = PlayerTwo.transform.position;
        PlayerTwo.transform.position = Vector2.MoveTowards(position, target, Velocity * Time.deltaTime);
    }
}
