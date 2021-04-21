using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour
{
    public int bounces;

    // Update is called once per frame
    void Update()
    {
        Reflecting(transform.position,bounces);
    }

    public void Reflecting(Vector3 initialPos ,int numberOfBounces)
    {
        initialPos = transform.position;
        Vector3 reflect = transform.forward;

        for (int i = 0; i < numberOfBounces; i++)
        {
            Ray ray = new Ray(initialPos,reflect);

            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
            
            if (hitInfo.collider != null)
            {
                reflect = Vector3.Reflect(ray.direction, hitInfo.normal);
                Debug.DrawLine(ray.origin, hitInfo.point, Color.green);
            }

            initialPos = hitInfo.point;
        }
    }
}
