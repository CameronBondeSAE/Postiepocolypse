using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZachFrench
{

    public class RayCastingMaths : MonoBehaviour
    {
        
        public int reflections;

        public List<RaycastHit> hitPoints;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            ExtraReflections();
        }

        void ExtraReflections()
        {
            Vector3 initialPosition = transform.position;
            Vector3 initialDirection = transform.forward;
            for (int i = 0; i < reflections; i++)
            {
                Ray ray = new Ray(initialPosition, initialDirection);

                RaycastHit hit = new RaycastHit();
                Physics.Raycast(ray, out hit);
                Vector3 reflection = Vector3.Reflect(ray.direction, hit.normal);
                if (hit.collider != null)
                {
                    Debug.DrawLine(ray.origin,hit.point,Color.red);
                    initialPosition = hit.point;
                }

                initialDirection = reflection;
            }
        }
    }
}

