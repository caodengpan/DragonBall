using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IdleState
{
    protected Player player;
    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<Player>();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
        float axisHor = player.plUI.GetAxisX();
        if (axisHor != 0)
        {
            player.curParentState.curState = player.moveState;
        }
        bool b = player.plUI.IsAttBtnPressed();
        if (b)
        {
            player.curParentState.curState = player.nextAtkState;
        }
        b = player.plUI.IsLightBallBtnPressed();
        if (b)
        {
            player.curParentState.curState = player.lightBallAttackState;
        }
    }

}
