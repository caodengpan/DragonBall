using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBallAttackState : SkillState
{
    public Material mateYellow;
    public Material mateBlue;
    public GameObject lightBall;
    public float animPlayTime2;
    public float animPlayTime3;
    public float ballMoveSpeed;
    protected ParticleSystem ps;
    protected Coroutine playLightBallAttack;
    protected Player player;

    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<Player>();
        ps = lightBall.GetComponent<ParticleSystem>();
        lightBall.SetActive(false);
        skillP = lightBall.transform.parent;
    }
    public void SetMaterial(Material m)
    {
        ps.GetComponent<ParticleSystemRenderer>().material.CopyPropertiesFromMaterial(m);
    }
    public override void StateStart()
    {
        base.StateStart();
        playLightBallAttack = StartCoroutine(PlayLightBallAttack());
    }

    protected IEnumerator PlayLightBallAttack()
    {
        while (countPlayTime > 0)
        {
            yield return new WaitForFixedUpdate();
        }
        lightBall.SetActive(true);
        countPlayTime = animPlayTime2;
        while (countPlayTime > 0)
        {
            yield return new WaitForFixedUpdate();
        }
        mCharacter.charAnim.SetTrigger("LightBallAttack-Attack");
        countPlayTime = animPlayTime3;
        SeparateFromPlayer(lightBall.transform);
        while (countPlayTime > 0)
        {
            yield return new WaitForFixedUpdate();
            lightBall.transform.position += player.transform.forward * ballMoveSpeed * Time.deltaTime;
        }
        player.curParentState.curState = player.idleState;
    }

    public override void StateEnd()
    {
        base.StateEnd();
        lightBall.SetActive(false);
        MergeToPlayer(lightBall.transform);
        if (playLightBallAttack != null)
        {
            StopCoroutine(playLightBallAttack);
        }
    }
}
