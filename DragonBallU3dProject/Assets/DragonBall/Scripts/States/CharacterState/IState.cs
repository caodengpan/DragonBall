using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IState : MonoBehaviour
{
    public string animStr;
    public float animPlayTime;
    protected float countPlayTime;
    protected Character mCharacter;
    protected virtual  void Awake()
    {
        mCharacter = GetComponent<Character>();
    }
    public virtual void StateStart()
    {
        if (animStr != "")
        {
            mCharacter.charAnim.SetTrigger(animStr);
        }
        countPlayTime = animPlayTime;
    }
    public virtual void StateUpdate()
    {
        if(countPlayTime <= 0)
        {
            countPlayTime = 0;
        }
        else
        {
            countPlayTime -= Time.deltaTime;
        }
    }
    public virtual void StateEnd() { }
}
