using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBAirBall : MonoBehaviour {

    [SerializeField]
    private float trackDelta = 0.2f;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform initPos;
    private float t;
	private void OnEnable()
    {
        transform.position = initPos.position;
        transform.LookAt(target);
        t = 0;
        transform.SetParent(null);
    }
    private void Update()
    {
        if(Vector3.Distance(target.position , transform.position) > 3f)
        {
            
            transform.position += transform.forward * speed*Time.deltaTime;
        }
        if (t < trackDelta)
        {
            t += Time.deltaTime;
        }
        else
        {
            t = 0;
            transform.LookAt(target);
        }
    }
    private void OnDisable()
    {
        transform.position = initPos.position;
    }

}
