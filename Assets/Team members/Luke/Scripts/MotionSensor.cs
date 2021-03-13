using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class MotionSensor : MonoBehaviour
    {
        public float pingDuration;
        public float pingWaitTime;
        public List<Vector3> sensedRigidbodies;
        
        private float maxPingWaitTime;

        void Start()
        {
            maxPingWaitTime = pingWaitTime;
        }

        public void OnTriggerEnter(Collider other)
        {
            sensedRigidbodies.Add(other.transform.position);
        }

        public IEnumerator OnTriggerStay(Collider other)
        {
            Rigidbody sensedRigidbody = other.attachedRigidbody;
            Vector3 velocity = sensedRigidbody.velocity;

            pingWaitTime -= Time.deltaTime;

            if (velocity.magnitude > 0 && pingWaitTime > 0)
            {
                //example but this should shoot out once
                Debug.Log("detecting Rigidbody at " + sensedRigidbody.transform.position);
            }
            
            else if (pingWaitTime <= 0)
            {
                yield return new WaitForSeconds(pingDuration);
                pingWaitTime = maxPingWaitTime; 
            }
        }

        public void OnTriggerExit(Collider other)
        {
            sensedRigidbodies.Remove(other.transform.position);
        }
    }
}
