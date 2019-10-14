using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagitoSuperSayin1IdleState : SuperSayin1IdleState
{
    protected Vagito vagito;
    protected override void Awake()
    {
        base.Awake();
        vagito = GetComponent<Vagito>();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
        bool b = vagito.vagitoUI.IsAirBladeBtnPreesed();
        if (b)
        {
            vagito.curParentState.curState = vagito.airBladeAttackState;
        }
        b = vagito.vagitoUI.IsKameBtnPressed();
        if (b)
        {
            vagito.curParentState.curState = vagito.kamehamehaState;
        }
    }
}
