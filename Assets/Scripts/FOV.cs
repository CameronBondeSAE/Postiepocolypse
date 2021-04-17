using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Damien
{
    public class FOV : MonoBehaviour
    {
        public LayerMask targets;

        public float viewRadius = 30f;
        [Range(0, 360)] public float viewAngle = 90f;


        public List<GameObject> listOfTargets = new List<GameObject>();

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
            //clears the list of targets ready to scan the area again
            listOfTargets.Clear();
            //Collects all colliders that have the layermask marked as a target
            Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targets);
            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Collider target = targetsInViewRadius[i];
                //checks if the target that is inside the view range is also within the view cone
                Vector3 dirToTarget = (target.transform.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float distance = Vector3.Distance(transform.position, target.transform.position);

                    RaycastHit hit;
                    //checks if there is anything blocking the line of sight to the target
                    Physics.Raycast(transform.position, dirToTarget, out hit, distance);
                    if (hit.collider == targetsInViewRadius[i])
                    {
                        //adds the target to the list of valid Targets
                        listOfTargets.Add(target.gameObject);
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