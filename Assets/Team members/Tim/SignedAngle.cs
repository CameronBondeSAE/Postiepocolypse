using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZachFrench
{


    public class SignedAngle : MonoBehaviour
    {
        public GameObject target;
        public float angle;
        public Vector3 targetAngle;
        public Vector3 forward;
        public Rigidbody rb;
        public float speed = 8;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //assigning the distance from target to current location
            targetAngle = target.transform.position - transform.position;
            //setting up a forward vector 
            forward = transform.forward;
            //signed angle uses the distance from target and the forward of the object to calculate the angle 
            angle = Vector3.SignedAngle(targetAngle, forward, Vector3.up);
            Debug.Log(angle);
            //rb.rotation = new Quaternion(0, angle, 0, 0);
            rb.AddRelativeForce(targetAngle.normalized * speed);

            Debug.DrawLine(transform.position, target.transform.position);
        }
    }
}
