using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamehamehaState : SkillState
{
    public GameObject kameGO;
    public float kameInitScaleFactor;
    public float animPlayTime2;
    public string animStr2;
    public float animPlayTime3;
    public float ballMoveSpeed;
    public float initBright;
    protected LensFlare fl;
    protected TrailRenderer trailRe;
    protected Transform lightBallTr;
    protected Coroutine playKame;
    protected Player player;
    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<Player>();
        kameGO.SetActive(false);
        lightBallTr = kameGO.transform.Find("LightBall");
        trailRe = lightBallTr.GetComponentInChildren<TrailRenderer>();
        lightBallTr.gameObject.SetActive(false);
        skillP = lightBallTr.parent;
        fl = kameGO.GetComponent<LensFlare>();
        fl.brightness = initBright;
        trailRe.time = 3f;
    }
    public override void StateStart()
    {
        base.StateStart();
        playKame = StartCoroutine(PlayKame());
    }
    protected IEnumerator PlayKame()
    {
        kameGO.SetActive(true);
        Vector3 v = player.transform.forward;
        while (countPlayTime > 0)
        {
            yield return new WaitForFixedUpdate();
            fl.brightness += 0.02f* Time.deltaTime;
        }
        player.charAnim.SetTrigger(animStr2);
        yield return new WaitForSeconds(animPlayTime2);
        countPlayTime = animPlayTime3;
        lightBallTr.gameObject.SetActive(true);
        SeparateFromPlayer(lightBallTr);
        while (countPlayTime > 0)
        {
            yield return new WaitForFixedUpdate();
            lightBallTr.position += v * ballMoveSpeed * Time.deltaTime;
        }
        player.curParentState.curState = player.idleState;
        
    }
    public override void StateEnd()
    {
        base.StateEnd();
        if (playKame != null)
        {
            StopCoroutine(playKame);
        }
        fl.brightness = initBright;
        MergeToPlayer(lightBallTr);
        trailRe.Clear();
        kameGO.SetActive(false);
        lightBallTr.gameObject.SetActive(false);
    }
}
