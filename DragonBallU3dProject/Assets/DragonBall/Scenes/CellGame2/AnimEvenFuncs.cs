using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AnimEvenFuncs : MonoBehaviour {

    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private Transform hitPos;
    [SerializeField]
    private ParticleSystem hitEffect;
    void AttackFrameTrigger(string str)
    {
        
    }
    void HitFrameTrigger(string str)
    {
        string[] ts = str.Split('_');
        //for(int i = 0; i < ts.Length; i++)
        //{
        //    print(ts[i]);
        //}
        Transform tar = null;
        string str2 = ts[1] + "_" + ts[2];
        //print(str2);
        switch (ts[0])
        {
            case "behit":
                tar = hitPos.Find(str2);
                break;
            case "block":
                GameObject go = UnityTool.FindChild(gameObject, str2);
                tar = go.transform;
                break;
        }
        hitEffect.transform.position = tar.position;
        hitEffect.Play();
        print(tar.name);
    }
}
