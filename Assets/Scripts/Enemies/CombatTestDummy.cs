using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTestDummy : MonoBehaviour
{
    private Animation anim;
    public void Damage(float amount)
    {
        Debug.Log(amount + " Damage taken");
    }
    private void Awake()
    {
        anim = GetComponent<Animation>();
    }
}
