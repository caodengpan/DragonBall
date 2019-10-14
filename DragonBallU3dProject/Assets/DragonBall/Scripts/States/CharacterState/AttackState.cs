using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    public AttackState nextAtkState;
    public GameObject effectGO;
    protected float atkDeltaTime;
    protected Player mPlayer;
    protected override void Awake()
    {
        base.Awake();
        if (effectGO != null)
        {
            effectGO.SetActive(false);
        }
        mPlayer = GetComponent<Player>();
    }
    public override void StateStart()
    {
        base.StateStart();
        if (effectGO != null)
        {
            effectGO.SetActive(true);
        }
        mPlayer.nextAtkState = nextAtkState;
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
        if (countPlayTime <= 0)
        {
            mPlayer.curParentState.curState = mPlayer.idleState;
        }
    }
    public override void StateEnd()
    {
        base.StateEnd();
        if (effectGO != null)
        {
            effectGO.SetActive(false);
        }
    }
}
