using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagitoSuperSayin1State : SuperSayin1State
{
    public AirBladeAttackState airBladeAttackState;
    public KamehamehaState kamehamehaState;

    protected Vagito vagito;

    protected override void Awake()
    {
        base.Awake();
        vagito = GetComponent<Vagito>();
    }
    public override void StateStart()
    {
        base.StateStart();
        vagito.airBladeAttackState = airBladeAttackState;
        vagito.kamehamehaState = kamehamehaState;
    }
}
