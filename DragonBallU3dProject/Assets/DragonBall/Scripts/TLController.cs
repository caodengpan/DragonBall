using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEditor;
using UnityEngine.Playables;

public class TLController : MonoBehaviour {

    public PlayableDirector director;
    public List<PlayableAsset> playableAssets;
    private int index;
	// Use this for initialization
	void Start () {
        
        director.stopped += OnStoped;
        director.Play(playableAssets[index]);
    }

    private void OnStoped(PlayableDirector pd)
    {
        index++;
        if(index< playableAssets.Count)
        {
            director.Play(playableAssets[index]);
        }
        
    }
    [MenuItem("Tools/EditorViewToCamView")]
    public static void EditorViewToCamView()
    {
        Debug.Log(Camera.allCameras.Length);
        Camera[] cams = SceneView.GetAllSceneCameras();
        if (cams.Length > 0)
        {
            Camera.main.transform.parent.position =cams[0].transform.position;
            Camera.main.transform.parent.eulerAngles = cams[0].transform.eulerAngles;
        }
    }

    // Update is called once per frame
	void Update () {
        

	}
}
