using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBCreateLitBall : MonoBehaviour {

    
    public float trackDelta,speed;
    [SerializeField]
    private GameObject pref;
    [SerializeField]
    private Transform targetTr, initPosTr;
    private void OnEnable()
    {

        DBAirBall ball = Instantiate(pref, null).GetComponent<DBAirBall>();
        ball.SetValue(targetTr, initPosTr,trackDelta,speed);
    }
}
