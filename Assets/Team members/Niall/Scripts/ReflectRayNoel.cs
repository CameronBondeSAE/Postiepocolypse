using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Niall
{
    public class ReflectRayNoel : MonoBehaviour
    {
        public int maxReflectCount = 3;
        public int maxStepDist = 100;
        
        private void OnDrawGizmos()
        {
            DrawReflectPath(transform.position + transform.forward * 0.75f, transform.forward, maxReflectCount);
        }

        void DrawReflectPath(Vector3 pos, Vector3 dir, int reflectsRemaining)
        {
            if (reflectsRemaining == 0)
            {
                return;
            }

            Vector3 startingpos = pos;

            Ray ray = new Ray(pos, dir);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxStepDist))
            {
                dir = Vector3.Reflect(ray.direction, hit.normal);
                pos = hit.point;
            }
            else
            {
                pos += dir * maxStepDist;
            }
            
            Gizmos.color = Color.green;
            Gizmos.DrawLine(startingpos, pos);

            DrawReflectPath(pos, dir, reflectsRemaining - 1);
        }

        void Update()
        {
            transform.Rotate(0f, 0.5f * Time.deltaTime, 0f);
        }
    }
}