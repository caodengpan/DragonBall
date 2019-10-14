using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Transform skillTr;
    public static BattleManager ins;

    private void Awake()
    {
        ins = this;
    }
}
