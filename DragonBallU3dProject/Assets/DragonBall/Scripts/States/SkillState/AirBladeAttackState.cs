using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBladeAttackState : SkillState
{
    public string animStr2;
    public float animPlayTime2;
    public GameObject airBladeGO;

    protected Vagito vagito;
    protected Coroutine playAirBladeAttack;

    protected override void Awake()
    {
        base.Awake();
        vagito = GetComponent<Vagito>();
        airBladeGO.SetActive(false);
    }
    public override void StateStart()
    {
        base.StateStart();
        playAirBladeAttack = StartCoroutine(PlayAirBladeAttack());
    }
    protected IEnumerator PlayAirBladeAttack()
    {
        airBladeGO.SetActive(true);
        float length = 0f;
        while (countPlayTime > 0)
        {
            if(length < 0.6)
            {
                length += Time.deltaTime * 3f;
            }
            yield return null;
            airBladeGO.transform.localScale = new Vector3(1f,Mathf.Sin(countPlayTime*35).Remap(-1,1,0.4f,0.8f), length);
        }
        vagito.charAnim.SetTrigger(animStr2);
        yield return new WaitForSeconds(animPlayTime2);
        vagito.curParentState.curState = vagito.idleState;
    }

    public override void StateEnd()
    {
        base.StateEnd();
        Vector3 v = airBladeGO.transform.localScale;
        airBladeGO.transform.localScale = new Vector3(v.x, v.y, 0f);
        airBladeGO.SetActive(false);
    }
}
