using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vagito : Sayin
{
    public AirBladeAttackState airBladeAttackState;
    public KamehamehaState kamehamehaState;
    public VagitoUI vagitoUI;
    protected override void Start()
    {
        base.Start();
        InitComp();
    }
    public void InitComp()
    {
        charAttr = new CharacterAttr(100f, 12f, 10f, this);
    }
}
