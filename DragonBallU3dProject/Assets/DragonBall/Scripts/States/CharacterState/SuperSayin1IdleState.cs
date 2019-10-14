using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSayin1IdleState : PlayerIdleState
{
    public Sayin sayin;
    protected override void Awake()
    {
        base.Awake();
        sayin = GetComponent<Sayin>();
    }
}
