using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLTurnState : MonoBehaviour {

    [SerializeField]
    private Material[] matesO;
    [SerializeField]
    private Material[] matesT;
    [SerializeField]
    private SkinnedMeshRenderer _mR;
    private void OnEnable()
    {
        TurnMeterials(matesT);
    }
    // Use this for initialization
    public void TurnMeterials(Material[] mates)
    {
        for (int i = 0; i < mates.Length; i++)
        {
            _mR.materials[i].CopyPropertiesFromMaterial(mates[i]);
        }
    }
    private void OnDisable()
    {
        TurnMeterials(matesO);
    }
}
