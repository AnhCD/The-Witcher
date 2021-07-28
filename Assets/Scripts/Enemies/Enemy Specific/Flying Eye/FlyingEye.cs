using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : Entity
{
    public FlyEye_IdleState idleState { get; private set; }
    public FlyEye_MoveState moveState { get; private set; }
    public FlyEye_PlayerDetectedState playerDetectedState { get; private set;}
    public FlyEye_ChargeState chargeState { get; private set; }
    public FlyEye_LookForPlayerState lookForPlayerState { get; private set; }
    public FlyEye_MeleeAttackState meleeAttackState { get; private set; }
    public FlyEye_StunState stunState { get; private set; }
    public FlyEye_DeadState deadState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    private Transform meleeAttackPosition;

    public void Start()
    {
        stateMachine.Intialize(moveState);
    }

    public override void Awake()
    {
        base.Awake();

        moveState = new FlyEye_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new FlyEye_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new FlyEye_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new FlyEye_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new FlyEye_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new FlyEye_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        stunState = new FlyEye_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new FlyEye_DeadState(this, stateMachine, "dead", deadStateData, this);

        
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);
        if(isDead)
        {
            stateMachine.ChangeState(deadState);
        }

        else if(isStunned && stateMachine.currentState != stunState)
        {
            stateMachine.ChangeState(stunState);
        }

        
    }
    
}
