using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Entity
{
    public Goblin_MoveState moveState { get; private set; }
    public Goblin_IdleState idleState { get; private set; }
    public Goblin_PlayerDetectedState playerDetectedState { get; private set;}
    public Goblin_LookForPlayerState lookForPlayerState {get; private set; }
    public Goblin_MeleeAttackState meleeAttackState { get; private set; }
    public Goblin_DeadState deadState {get; private set; }
    public Goblin_StunState stunState { get; private set; }
    public Goblin_DodgeState dodgeState { get; private set; }
    public Goblin_RangeAttackState rangeAttackState { get; private set; }
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    public D_DodgeState dodgeStateData;
    [SerializeField]
    public D_RangeAttackState rangeAttackStateData;

    [SerializeField]
    private Transform meleeAttackPosition;
    [SerializeField]
    private Transform rangeAttackPosition;

    public void Start()
    {
        stateMachine.Intialize(moveState);
    }

    public override void Awake()
    {
        base.Awake();

        moveState = new Goblin_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new Goblin_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new Goblin_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        meleeAttackState = new Goblin_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this); 
        lookForPlayerState = new Goblin_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new Goblin_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new Goblin_DeadState(this, stateMachine, "dead", deadStateData, this);
        dodgeState = new Goblin_DodgeState(this, stateMachine, "dodge", dodgeStateData, this);
        rangeAttackState = new Goblin_RangeAttackState(this, stateMachine, "rangeAttack",rangeAttackPosition, rangeAttackStateData, this);
        
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
        else if(CheckPlayerInMaxAgroRange())
        {
            stateMachine.ChangeState(rangeAttackState);
        }
        else if(!CheckPlayerInMinAgroRange())
        {
            lookForPlayerState.SetTurnImmediately(true);
            stateMachine.ChangeState(lookForPlayerState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}
