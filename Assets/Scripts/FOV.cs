﻿using System;
using System.Collections;
using System.Collections.Generic;
using Tanks;
using tripolygon.UModeler;
using UnityEngine;
using UnityEngine.PlayerLoop;


namespace Damien
{
    public class FOV : MonoBehaviour
    {
        public GameObject owner;
        public LayerMask targets;
        public LayerMask obstacle;

        public float viewRadius;
        [Range(0, 360)] public float viewAngle = 90;


        public List<Collider> listOfTargets = new List<Collider>();

        private void Start()
        {
            StartCoroutine("SeeThings", 0.2f);
        }

        IEnumerator SeeThings(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                DetectThings();
            }
        }

        void DetectThings()
        {
            listOfTargets.Clear();
            Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targets);
            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Collider target = targetsInViewRadius[i];
                Vector3 dirToTarget = (target.transform.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float distance = Vector3.Distance(transform.position, target.transform.position);

                    RaycastHit hit;

                    Physics.Raycast(transform.position, dirToTarget, out hit, distance);
                    
                    if(hit.collider == targetsInViewRadius[i])
                    {
                        listOfTargets.Add(target);
                    }
                }
            }
        }

        public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                angleInDegrees += transform.eulerAngles.y;
            }

            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
    }
}