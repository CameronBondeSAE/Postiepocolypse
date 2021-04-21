using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.Effects;
using UnityEngine;


namespace AJ
{

    public class ReflectRayCast : MonoBehaviour
    {
        
        public int ReflectionCount = 50;
        public float ReflectDistance = 200f;

        private void Update()
        {
            Laser();
        }

        void Laser()
        {
            DrawReflectionPattern(transform.position + transform.forward * 0.75f, transform.forward, ReflectionCount);
        }

        private void DrawReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
        {
            if (reflectionsRemaining == 0)
            {
                return;
            }

            Vector3 startingPosition = position;

            Ray ray = new Ray(position, direction);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, ReflectDistance))
            {
                direction = Vector3.Reflect(direction, hit.normal);
                position = hit.point;
            }
            else
            {
                position += direction * ReflectDistance;
            }

            //Gizmos.color = Color.yellow;
            //Gizmos.DrawLine(startingPosition, position);

            Debug.DrawLine(startingPosition, position, Color.magenta);

            DrawReflectionPattern(position, direction, reflectionsRemaining - 1);


        }

        
    }
}

