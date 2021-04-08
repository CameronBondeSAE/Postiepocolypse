using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleCalculator : MonoBehaviour
{
    public GameObject target;
    public float angle;
    public Vector3 targetDir;
    public Rigidbody rb;
    public float speed = 10;
        
    // Update is called once per frame
    void Update()
    {
        targetDir = target.transform.position - transform.position;
        angle = Vector3.Angle(targetDir, transform.forward);
        rb.velocity = targetDir.normalized * speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(target.transform.position, transform.position);
        
        
    }
}
