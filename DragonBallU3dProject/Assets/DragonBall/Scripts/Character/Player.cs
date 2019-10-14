using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    
    public PlayerUI plUI;

    public LightBallAttackState lightBallAttackState;
    public AttackState atk1State;
    public AttackState atk2State;
    public AttackState atk3State;
    public AttackState atk4State;

    public AttackState nextAtkState;

    protected override void Start()
    {
        base.Start();
    }


}
