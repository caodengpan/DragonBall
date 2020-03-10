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
    [SerializeField]
    private ParticleSystem explodeEffect;
    private Vector3 tarPos;
    private float t;
    private bool canUpdate;
	private void OnEnable()
    {
        transform.position = initPos.position;
        transform.LookAt(target);
        tarPos = target.position;
        t = 0;
        transform.SetParent(null);
        canUpdate = true;
    }
    public void SetValue(Transform tar, Transform init, float trDelta, float sp)
    {
        target = tar;
        initPos = init;
        trackDelta = trDelta;
        speed = sp;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        if (canUpdate)
        {
            if (Vector3.Distance(tarPos, transform.position) > 3f)
            {

                transform.position += transform.forward * speed * Time.deltaTime;
            }
            else
            {
                canUpdate = false;
                if (explodeEffect != null)
                {
                    StartCoroutine(PlayExplode());
                }
            }
            if (t < trackDelta)
            {
                t += Time.deltaTime;
            }
            else
            {
                t = 0;
                transform.LookAt(target);
                tarPos = target.position;
            }
        }
       
    }
    IEnumerator PlayExplode()
    {
        
        explodeEffect.gameObject.SetActive(true);
        float t = 0;
        while (t<explodeEffect.main.duration)
        {
            t += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        transform.position = initPos.position;
    }

}
