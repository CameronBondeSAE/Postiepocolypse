using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastReflect : MonoBehaviour
{
    public int reflectionCount = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Reflect(transform.position,reflectionCount);
    }

    private void Reflect(Vector3 initPos,int reflectionCount)
    {
        initPos = transform.position;
        Vector3 reflPos = transform.forward;
        for (int i = 0; i < reflectionCount; i++)
        {
            Ray ray = new Ray(initPos, reflPos);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);

            if (hitInfo.collider != null)
            {
                reflPos = Vector3.Reflect(ray.direction, hitInfo.normal);
                Debug.DrawLine(ray.origin, hitInfo.point, Color.white);
               
            }
            initPos = hitInfo.point;
            
        }
    }
}
