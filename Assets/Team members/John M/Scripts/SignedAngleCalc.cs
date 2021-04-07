using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JonathonMiles
{
    public class SignedAngleCalc : MonoBehaviour
    {
        public GameObject target;
        public float angle;
        public Vector3 targetDir;
        public Rigidbody rb;
        public float speed = 10;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //assigning the distance from target to current location
            targetDir = target.transform.position - transform.position;
            //signed angle uses the distance from target and the forward of the object to calculate the angle 
            angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);
            Debug.Log(angle);
            rb.rotation = new Quaternion(0, angle, 0, 0);
            rb.AddForce(targetDir.normalized * speed);

            Debug.DrawLine(transform.position, target.transform.position);
        }
    } 
}


