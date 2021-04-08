using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZachFrench
{
    
    public class AngleTesting : MonoBehaviour
    {
        public GameObject target;
        public Vector3 TargetAngle;
        public float angle;
        public Rigidbody rb;
        public float speed = 10;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            TargetAngle = target.transform.position - transform.position;
            angle = Vector3.Angle(TargetAngle, transform.forward);
            Debug.Log(angle);
            rb.velocity = TargetAngle.normalized * speed;
            
            
            Debug.DrawLine(transform.position, target.transform.position);
        }
    }
}
