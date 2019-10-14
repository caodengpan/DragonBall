using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathTest : MonoBehaviour
{
    public CPC_CameraPath cameraPath;

    private void Start()
    {
        transform.position = cameraPath.GetBezierPosition(1, 0.5f);
    }
}
