using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CellFracture : MonoBehaviour {

    [SerializeField]
    private Transform target;
	[MenuItem("Tools/Fracture/AddBoxColliderAndRigidBody")]
    public static void AddBoxColliderAndRigidBody()
    {
        GameObject g = Selection.activeGameObject;
        Transform[] trs = g.transform.GetComponentsInChildren<Transform>();
        for(int i = 1; i < trs.Length; i++)
        {
            Component com = trs[i].GetComponent<BoxCollider>();
            if (com != null)
            {
                DestroyImmediate(com);
            }
            trs[i].gameObject.AddComponent<BoxCollider>();
            com = null;
            com = trs[i].GetComponent<Rigidbody>();
            if (com != null)
            {
                DestroyImmediate(com);
            }
            Rigidbody rb = trs[i].gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }
   
    private void OnEnable()
    {
        StartFractrue();
    }
    private void StartFractrue()
    {
        Rigidbody[] rbs = target.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rbs.Length; i++)
        {
            rbs[i].isKinematic = false;
        }
        Rigidbody rigi = target.GetChild(3).GetComponent<Rigidbody>();
        rigi.AddExplosionForce(60, rigi.position, 100f);
    }
}
