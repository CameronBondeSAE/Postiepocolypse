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
        
        //use for sending positions to others in interest
        //possibly turn into an event??
        public List<Vector3> sensedRigidbodies;
        
        private float maxPingWaitTime;

        void Start()
        {
            maxPingWaitTime = pingWaitTime;
        }

        //use for sending positions
        public void OnTriggerEnter(Collider other)
        {
            sensedRigidbodies.Add(other.transform.position);
        }

        //Using the IEnumerator with a OnTrigger to get the other colliders rigidbody
        public IEnumerator OnTriggerStay(Collider other)
        {
            Rigidbody sensedRigidbody = other.attachedRigidbody;
            Vector3 velocity = sensedRigidbody.velocity;

            pingWaitTime -= Time.deltaTime;

            //if the rigidbody is moving within the time frame of the ping
            if (velocity.magnitude > 0 && pingWaitTime > 0)
            {
                //example but this should ideally shoot out once
                Debug.Log("detecting Rigidbody at " + sensedRigidbody.transform.position);
            }
            
            //then the delay time for next ping
            else if (pingWaitTime <= 0)
            {
                yield return new WaitForSeconds(pingDuration);
                pingWaitTime = maxPingWaitTime; 
            }
        }

        //use for sending positions
        public void OnTriggerExit(Collider other)
        {
            sensedRigidbodies.Remove(other.transform.position);
        }
    }
}
