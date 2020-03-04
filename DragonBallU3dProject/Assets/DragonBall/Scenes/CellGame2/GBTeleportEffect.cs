using UnityEngine;
using System.Collections;

public class GBTeleportEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem effect;
    [SerializeField]
    private SkinnedMeshRenderer smr;
    private float timer;
    private bool canUpdate;
    private void OnEnable()
    {
        if (effect != null)
        {
            effect.Play();
        }
        
        canUpdate = true;
    }

    private void Update()
    {
        if (canUpdate)
        {
            if (timer < effect.main.duration)
            {
                timer += Time.deltaTime;
            }
            else
            {
                smr.enabled = true;
                canUpdate = false;
            }
        }
       
    }
    private void OnDisable()
    {
        smr.enabled = false;
        timer = 0;
        if (effect != null)
        {
            effect.Play();
        }
            
    }
}
