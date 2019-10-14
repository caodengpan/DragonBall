using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayinNormalState : SkillParentState
{
    public AttackState atk1State;
    public AttackState atk2State;
    public AttackState atk3State;
    public AttackState atk4State;
    public PlayerMoveState playerMoveState;
    public LightBallAttackState lightBallAttackState;
    protected Sayin sayin;
    protected override void Awake()
    {
        base.Awake();
        sayin = GetComponent<Sayin>();
    }

    public override void StateStart()
    {
        base.StateStart();
        atk1State.nextAtkState = atk2State;
        atk2State.nextAtkState = atk3State;
        atk3State.nextAtkState = atk4State;
        atk4State.nextAtkState = atk1State;
        sayin.atk1State = atk1State;
        sayin.atk2State = atk2State;
        sayin.atk3State = atk3State;
        sayin.atk4State = atk4State;
        sayin.nextAtkState = atk1State;
        sayin.idleState = idleState;
        sayin.moveState = playerMoveState;
        sayin.lightBallAttackState = lightBallAttackState;
        lightBallAttackState.SetMaterial(lightBallAttackState.mateBlue);
        curState = sayin.idleState;
    }
}
