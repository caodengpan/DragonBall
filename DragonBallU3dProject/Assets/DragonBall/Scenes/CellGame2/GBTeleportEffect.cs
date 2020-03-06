using UnityEngine;
using System.Collections;

public class GBTeleportEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem effect;
    [SerializeField]
    private SkinnedMeshRenderer[] smrs;
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
                for(int i = 0; i < smrs.Length; i++)
                {
                    smrs[i].enabled = true;
                }
               
                canUpdate = false;
            }
        }
       
    }
    private void OnDisable()
    {
        for (int i = 0; i < smrs.Length; i++)
        {
            smrs[i].enabled = false;
        }
           
        timer = 0;
        if (effect != null)
        {
            effect.Play();
        }
            
    }
}
