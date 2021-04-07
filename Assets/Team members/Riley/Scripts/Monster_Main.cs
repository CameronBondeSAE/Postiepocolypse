using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEditor;
using UnityEngine;

namespace RileyMcGowan
{
    public class Monster_Main : MonoBehaviour
    {
        private AntAIAgent antAIAgent;
        public FakeTarget currentTarget;
        public float safeDistance = 1f;
        private float directionToTarget;
        private Vector3 vectorToTarget;
        public bool invertDirection;
        private Vector3 vectorNormalised;
        private void Awake()
        {
            antAIAgent = GetComponent<AntAIAgent>();
        }

        void Start()
        {
            antAIAgent.SetGoal("At Target");
        }

        private void Update()
        {
            if (currentTarget != null)
            {
                if (invertDirection != true)
                {
                    vectorToTarget = currentTarget.transform.position - transform.position;
                }
                else
                {
                    vectorToTarget = transform.position - currentTarget.transform.position;
                }
                
                if (vectorToTarget != null)
                {
                    vectorNormalised = vectorToTarget.normalized;
                    Debug.Log("The vectorToTarget is " + vectorToTarget);
                    directionToTarget = Vector3.Angle(vectorToTarget, transform.forward);
                    Debug.Log("The directionToTarget is " + directionToTarget);
                    float signedToTarget = Vector3.SignedAngle(vectorToTarget, transform.forward, transform.up);
                    Debug.Log("The Signed vector is " + signedToTarget);
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (vectorToTarget != null & currentTarget != null)
            {
                Gizmos.DrawLine(transform.position, currentTarget.transform.position);
            }
        }
    }
}