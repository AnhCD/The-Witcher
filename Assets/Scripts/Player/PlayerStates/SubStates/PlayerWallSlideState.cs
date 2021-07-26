using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(!isExittingState)
        {
            if(grabInput && yInput == 0)
            {
                stateMachine.ChangeState(player.WallGrabState);
            }
        }
        core.Movement.SetVelocityY(-playerData.wallSlideVelocity);

        
    }
}
