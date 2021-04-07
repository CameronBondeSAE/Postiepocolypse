using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleCalculator : MonoBehaviour
{
    public GameObject target;
    public float angle;
        
    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = target.transform.position - transform.position;
        //angle = Vector3.Angle(target.transform.position, transform.forward);
        angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(target.transform.position, transform.position);
        
        
    }
}
