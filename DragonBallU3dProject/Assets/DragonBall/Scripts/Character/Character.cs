using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterAttr charAttr;
    public CharacterUI charUI;
    public Animator charAnim;
    public SkinnedMeshRenderer charMR;

    public MoveState moveState;
    public IdleState idleState;

    public SkillParentState charParentState;

    public SkillParentState curParentState;
 


    private CharacterUI mCharUI;

    protected virtual void Start()
    {
        curParentState = charParentState;
        charParentState.StateStart();
    }
    private void Update()
    {
        if (curParentState != null)
        {
            curParentState.StateUpdate();
        }
    }
    private void OnDisable()
    {
        if (curParentState != null)
        {
            curParentState = null;
        }
    }

}
public class CharacterInfo
{
    public Sprite headSp;
    public string name;
    public GameObject prefab;
    public CharacterAttr charAttr;
}
public class CharacterAttr
{
    public float hp
    {
        get
        {
            return mHp;
        }
        set
        {
            if (value >= 0)
            {
                mHp = value;
                mCharacter.charUI.Hp = value;
            }
        }
    }
    public float moveSpeed
    {
        get
        {
            return mMoveSpeed;
        }
        set
        {
            if (value > 0)
            {
                mMoveSpeed = value;
            }
        }
    }
    public float attackSpeed
    {
        get
        {
            return mAttackSpeed;
        }
        set
        {
            if (value > 0)
            {
                mAttackSpeed = value;
            }
        }
    }

    private float mHp;
    private float mMoveSpeed;
    private float mAttackSpeed;
    private Character mCharacter;

    public CharacterAttr(float h,float ms,float asp, Character character)
    {
        mCharacter = character;
        hp = h;
        moveSpeed = ms;
        attackSpeed = asp;
    }
    public virtual void InitComp(){ }
}