using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class Angles : MonoBehaviour
    {
        private Vector3 directionPos;
        public float speed;
        public Rigidbody rb;

        public Transform targetPos;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            MoveToTargetPos();
        }

        public void MoveToTargetPos()
        {
            float angle = Vector3.Angle(directionPos, transform.forward);
            float signedAngle = Vector3.SignedAngle(directionPos, transform.forward, transform.up);
            
            directionPos = targetPos.transform.position - transform.position;
            
            rb.rotation = Quaternion.Euler(0,angle,0);
            rb.AddRelativeForce(0,0,speed);

            Debug.DrawLine(transform.position, targetPos.transform.position);
            
            Debug.Log("angle = " + angle);
            Debug.Log("SinnedAngle = " + signedAngle);
        }
    }
}
