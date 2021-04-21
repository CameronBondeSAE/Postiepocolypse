using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBouncing : MonoBehaviour
{
    public int noOfBounces;
    
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ReflectFromPoint(transform.position, noOfBounces);
        }
    }
    private void ReflectFromPoint(Vector3 initialPosition, int numberOfBounces)
    {
        Vector3 transformPosition = initialPosition;
        Vector3 initialReflection = transform.forward;
        for (int i = 0; i <= numberOfBounces; i++)
        {
            Ray ray = new Ray(transformPosition, initialReflection);
            RaycastHit rayOutput;
            Physics.Raycast(ray, out rayOutput);
            if (rayOutput.collider != null)
            {
                initialReflection = Vector3.Reflect(ray.direction, rayOutput.normal);
            }
            transformPosition = rayOutput.point;
            Debug.DrawLine(ray.origin, rayOutput.point, Color.green, 2);
        }
    }
    private void OnDrawGizmos()
    {
    }
}
