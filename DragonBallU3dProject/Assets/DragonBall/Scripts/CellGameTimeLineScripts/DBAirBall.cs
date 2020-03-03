using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBAirBall : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform initPos;
	private void OnEnable()
    {
        transform.position = initPos.position;
        transform.LookAt(target);
    }
    private void Update()
    {
        if(Vector3.Distance(target.position , transform.position) > 3f)
        {
            transform.LookAt(target);
            transform.position += transform.forward * speed*Time.deltaTime;
        }
    }
    private void OnDisable()
    {
        transform.position = initPos.position;
    }

}
