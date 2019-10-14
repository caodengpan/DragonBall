using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayinNormalIdleState : PlayerIdleState
{
    protected Sayin sayin;
    protected override void Awake()
    {
        base.Awake();
        sayin = GetComponent<Sayin>();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
        bool b = sayin.sayinUI.IsSuperSayin1BtnPressed();
        if (b)
        {
            sayin.curParentState.curState = sayin.superSayin1State;
            sayin.curParentState = sayin.superSayin1State;
        }
    }
}
