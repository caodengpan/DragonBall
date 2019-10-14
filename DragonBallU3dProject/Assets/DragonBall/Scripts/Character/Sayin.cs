using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sayin : Player
{
    public Material[] normalStateMaterials;
    public Material[] superSayin1StateMaterials;

    public SayinUI sayinUI;
    public SuperSayin1State superSayin1State;


    public void TurnMeterials(Material[] mates)
    {
        for (int i = 0; i < mates.Length; i++)
        {
            charMR.materials[i].CopyPropertiesFromMaterial(mates[i]);
        }
    }
    protected override void Start()
    {
        base.Start();
    }

}
