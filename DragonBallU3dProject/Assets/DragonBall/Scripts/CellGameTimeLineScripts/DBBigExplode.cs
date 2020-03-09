using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DBBigExplode : MonoBehaviour {

    public float litSpeed;
    public PostProcessVolume postProcess;
    public ParticleSystem ps;
    public CameraShake cameraShake;
    private Bloom bloom;
    private float litLevel;
    private float initLevel;
    public float timer;
    private void Awake()
    {
        bloom = postProcess.sharedProfile.GetSetting<Bloom>();
        initLevel = bloom.intensity.value;
    }
    private void OnEnable()
    {
        ps.Play();
        litLevel = initLevel;
        timer = 0;
        cameraShake.SetValue(6, 1.2f);
    }
    private void Update()
    {
        timer += Time.deltaTime;
       
        if (timer < ps.main.duration * 0.15)
        {
            
            litLevel += litSpeed*1.5f * Time.deltaTime;
            bloom.intensity.value = litLevel;
        }
        if (timer > ps.main.duration * 0.75 && timer < ps.main.duration)
        {
            litLevel -= litSpeed * Time.deltaTime;
            if (litLevel < initLevel)
            {
                litLevel = initLevel;
            }
            bloom.intensity.value = litLevel;
        }
    }
    private void OnDisable()
    {
        bloom.intensity.value = initLevel;
        cameraShake.enabled = false;
    }
}
