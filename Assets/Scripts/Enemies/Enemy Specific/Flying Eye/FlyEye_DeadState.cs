using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEye_DeadState : DeadState
{
    private FlyingEye enemy;

    public FlyEye_DeadState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, FlyingEye enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
