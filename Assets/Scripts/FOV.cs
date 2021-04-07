using System;
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
        public LayerMask target;
        public LayerMask obstacle;

        public float viewRadius;
        [Range(0, 360)] public float viewAngle = 360;
        
        

        public List<Transform> playerTargets = new List<Transform>();

        private void Start()
        {
            StartCoroutine("SeePlayers", 0.2f);
        }

        IEnumerator SeePlayers(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                DetectPlayer();
                
            }
        }

        void DetectPlayer()
        {
            playerTargets.Clear();
            Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, target);
            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Transform target = targetsInViewRadius[i].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float distance = Vector3.Distance(transform.position, target.position);
                    if (!Physics.Raycast(transform.position, dirToTarget, distance, obstacle))
                    {
                        playerTargets.Add(target);
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