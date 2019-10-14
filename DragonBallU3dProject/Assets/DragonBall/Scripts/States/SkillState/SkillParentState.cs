using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillParentState : SkillState
{
    public SkillParentState lastParentState;
    public IdleState idleState;
    public float duringTime;
    public float countDuringTime;

    public IState curState
    {
        get
        {
            return mCurState;
        }
        set
        {
            if (mCurState != null)
            {
                mCurState.StateEnd();
            }
            mCurState = value;
            if (mCurState != null)
            {
                mCurState.StateStart();
            }
        }
    }
    public IState mCurState;

    public override void StateStart()
    {
        base.StateStart();
        countDuringTime = duringTime;
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
        if (curState != null)
        {
            curState.StateUpdate();
        }
        if (countDuringTime <= 0)
        {
            countDuringTime = 0;
            if (lastParentState != null)
            {
                lastParentState.curState = lastParentState.idleState;
            }
        }
        else
        {
            countDuringTime -= Time.deltaTime;
        }
    }
    public override void StateEnd()
    {
        base.StateEnd();
        if (curState != null)
        {
            curState = null;
        }
        countDuringTime = 0;
    }


}
