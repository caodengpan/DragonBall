using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : IState
{
    public float coldingTime;
    protected float cd;
    protected Transform skillTr;
    protected Transform skillP;

    protected override void Awake()
    {
        base.Awake();
    }
    protected virtual void Start()
    {
        skillTr = BattleManager.ins.skillTr;
    }
    public override void StateStart()
    {
        base.StateStart();
        cd = coldingTime;
    }
    protected virtual void Update()
    {
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
        else
        {
            cd = 0;
        }
        
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
        
    }
    protected virtual void SeparateFromPlayer(Transform tr)
    {
        tr.SetParent(BattleManager.ins.skillTr);
        tr.localScale = tr.localScale / 3.8f;
    }
    protected virtual void MergeToPlayer(Transform tr)
    {
        tr.SetParent(skillP);
        tr.localScale = tr.localScale * 3.8f;
        tr.localPosition = Vector3.zero;
        tr.localRotation = Quaternion.identity;
    }
    public override void StateEnd()
    {
        base.StateEnd();

    }
 
}
