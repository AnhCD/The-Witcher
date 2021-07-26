using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public CollisionSenses CollisionSenses { get; private set; }
    public Movement Movement { get; private set; }
    private void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        if (!Movement || !CollisionSenses)
        {
            Debug.LogError("Missing Core Component");
            CollisionSenses = GetComponentInChildren<CollisionSenses>();
        }
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
    }
}