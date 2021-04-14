using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreatureController : MonoBehaviour
{
    public GameObject target;
    public bool move;
    private bool invertDirection;
    private float directionToTarget;
    private Vector3 vectorToTarget;
    private Vector3 vectorNormalised;
    private float signedToTarget;
    private Rigidbody rb;
    private CreatureDamage childHaveDamaged;
    private float safeDistance = 2;
    private float speed;
    private float rotateSpeed;
    private float perlinNoise;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        childHaveDamaged = GetComponentInChildren<CreatureDamage>();
    }

    void FixedUpdate()
    {
        perlinNoise = Mathf.PerlinNoise(Random.Range(1,10), Random.Range(1,10));
        invertDirection = childHaveDamaged.haveDamaged;
        if (invertDirection != true && rotateSpeed != 1)
        {
            rotateSpeed = 1;
            speed = 0.005f;
        }
        else
        {
            if (rotateSpeed != 2)
            {
                rotateSpeed = 2;
                speed = 1f;
            }
        }
        
        if (target == null)
        {
            Debug.Log("Target is not set!");
            return;
        }
        if (invertDirection != true)
        {
            vectorToTarget = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
        }
        else
        {
            vectorToTarget = transform.position - new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        }
        
        if (vectorToTarget != null)
        {
            vectorNormalised = vectorToTarget.normalized;
            //Debug.Log("The vectorToTarget is " + vectorToTarget);
            directionToTarget = Vector3.Angle(vectorToTarget, transform.forward);
            //Debug.Log("The directionToTarget is " + directionToTarget);
            signedToTarget = Vector3.SignedAngle(vectorToTarget, transform.forward, Vector3.up);
            //Debug.Log("The Signed vector is " + signedToTarget);
        }
        
        if (signedToTarget < 5 && perlinNoise > .1f)
        {
            if (signedToTarget > -1 && move == true)
            {
                Move();
            }
            else
            {
                transform.Rotate(0,rotateSpeed,0);
            }
        }
        else
        {
            transform.Rotate(0,-rotateSpeed,0);
        }
        
    }
    private void Move()
    {
        rb.velocity = vectorToTarget * speed;
    }
}
