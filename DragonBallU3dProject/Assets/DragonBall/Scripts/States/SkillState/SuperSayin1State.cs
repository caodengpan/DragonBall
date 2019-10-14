using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSayin1State : SkillParentState
{
    public GameObject airFlowYellowEffect;
    public float animPlayTime2;

    public MoveState moveState;
    public AttackState attackState;
    public LightBallAttackState lightBallAttackState;

    protected Sayin sayin;
    protected Coroutine playTurnToSuperSayin1;

    protected override void Awake()
    {
        base.Awake();
        sayin = GetComponent<Sayin>();
        airFlowYellowEffect.SetActive(false);
    }
    public override void StateStart()
    {
        base.StateStart();
        sayin.idleState = idleState;
        airFlowYellowEffect.SetActive(true);
        sayin.TurnMeterials(sayin.superSayin1StateMaterials);
        playTurnToSuperSayin1 = StartCoroutine(PlayTurnToSuperSayin1());
        sayin.sayinUI.TurnToSuperSayin1();
        lightBallAttackState.SetMaterial(lightBallAttackState.mateYellow);
    }
    protected IEnumerator PlayTurnToSuperSayin1()
    {
        yield return new WaitForSeconds(animPlayTime);
        sayin.charAnim.SetTrigger("SuperSayin-End");
        yield return new WaitForSeconds(animPlayTime2);
        curState = sayin.idleState;
        airFlowYellowEffect.SetActive(false);
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
    }
    public override void StateEnd()
    {
        base.StateEnd();
        airFlowYellowEffect.SetActive(false);
        if (playTurnToSuperSayin1 != null)
        {
            StopCoroutine(playTurnToSuperSayin1);
        }
    }

}
