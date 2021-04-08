using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglesDemoOutput : MonoBehaviour
{
    public GameObject target;
    public bool invertDirection;
    public float directionToTarget;
    public Vector3 vectorToTarget;
    public Vector3 vectorNormalised;
    public float signedToTarget;

    void Update()
    {
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

        float perlinNoise = Mathf.PerlinNoise(1, 0);
        if (signedToTarget < 5 && perlinNoise > .5f)
        {
            if (signedToTarget > -5)
            {
                //Move
            }
        }
        //else
        //{
            //if (signedToTarget > -5 && perlinNoise > -.5f)
            //{
            //    if (signedToTarget < 5)
            //    {
            //        //move
            //    }
            //}
        //}
    }
}
