using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapon weapon;

    private float velocityToSet;
    private bool setVelocity;

    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        setVelocity = false;

        weapon.EnterWeapon();
    }

    public override void Exit()
    {
        base.Exit();

        weapon.ExitWeapon();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(setVelocity)
        {
            player.SetVelocityX(velocityToSet * player.FacingDirection);
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        weapon.InitializeWeapon(this);
    }

    public void SetPlayerVelocity(float velocity)
    {
        player.SetVelocityX(velocity * player.FacingDirection);

        velocityToSet = velocity;
        setVelocity = true;
    }

    #region  Animation Triggers
    
    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        isAbilityDone = true;
    }
    #endregion
}
