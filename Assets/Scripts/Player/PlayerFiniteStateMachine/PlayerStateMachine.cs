using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState CurrenState { get; private set; }

    public void Initialize(PlayerState startingState)
    {
        CurrenState = startingState;
        CurrenState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        CurrenState.Exit();
        CurrenState = newState;
        CurrenState.Enter();
    }
}
