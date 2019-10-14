using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagitoNormalState : SayinNormalState
{
    

    protected Vagito vagito;

    protected override void Awake()
    {
        base.Awake();
        vagito = GetComponent<Vagito>();
    }
    public override void StateStart()
    {
        base.StateStart();
        vagito.idleState = idleState;
        atk1State.animStr = "NormalAttack-1";
        atk1State.animPlayTime = 0.5f;
        atk2State.animStr = "NormalAttack-2";
        atk2State.animPlayTime = 0.3f;
        atk3State.animStr = "NormalAttack-3";
        atk3State.animPlayTime = 0.7f;
        atk4State.animStr = "NormalAttack-4";
        atk4State.animPlayTime = 0.65f;
        
    }
}
