using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : MoveState
{
    protected Player player;
    protected Coroutine moveForward;
    protected Coroutine moveBack;
    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<Player>();
    }
    public override void StateStart()
    {
        base.StateStart();
        float axisVal = player.plUI.GetAxisX();
        if (axisVal > 0)
        {
            moveForward = StartCoroutine(MoveForward());
        }
        else
        {
            if (axisVal < 0)
            {
                moveBack = StartCoroutine(MoveBack());
            }
        }
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
        
    }

    public override void StateEnd()
    {
        base.StateEnd();
        if (moveBack != null)
        {
            StopCoroutine(moveBack);
        }
        if (moveForward != null)
        {
            StopCoroutine(moveForward);
        }
    }
    protected IEnumerator MoveForward()
    {
        float t = 0f;
        player.charAnim.SetTrigger("MoveForward");
        while (t < 0.3f)
        {
            t += Time.deltaTime;
            mCharacter.transform.position += mCharacter.transform.forward * mCharacter.charAttr.moveSpeed * Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        player.curParentState.curState = player.idleState;
    }
    protected IEnumerator MoveBack()
    {
        float t = 0f;
        player.charAnim.SetTrigger("MoveBack");
        while (t < 0.3f)
        {
            t += Time.deltaTime;
            mCharacter.transform.position -= mCharacter.transform.forward * mCharacter.charAttr.moveSpeed * Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        player.curParentState.curState = player.idleState;
    }
}
