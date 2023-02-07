using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe_Controll : SwipeDetector
{
    public Player_Movement _player;
    public PlatFromControl _platFroms1;
    public PlatFromControl _platFroms2;
    public PlatFromControl _platFroms3;

    public GameObject JumpEffectEffect;

    public float waitTime_jump;
    public float waitTime_Down;


    protected override void SwipedDirection(float angle, Movement currentDirection)
    {
        base.SwipedDirection(angle, currentDirection);
        if (currentDirection == Movement.Left)
        {
            _player.WalkDirection(-1);

        }
        else if (currentDirection == Movement.Right)
        {
            _player.WalkDirection(1);

        }
        else if (currentDirection == Movement.Up && waitTime_jump <= 0)
        {
            _platFroms1.PressToUp();
            _platFroms2.PressToUp();
            _platFroms3.PressToUp();
            _player.Jump();
            waitTime_jump = 0.25f;
        }
        else if (currentDirection == Movement.Down && waitTime_Down <= 0)
        {
            _platFroms1.PressToDrop();
            _platFroms2.PressToDrop();
            _platFroms3.PressToDrop();
            Instantiate(JumpEffectEffect, transform.position, transform.rotation, null);
            waitTime_Down = 0.3f;
        }

    }
}
