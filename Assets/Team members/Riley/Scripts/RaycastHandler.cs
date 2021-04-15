using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    public float distanceToPlatformInfo;
    public LayerMask RaycastHitLayer;
    private int maxRayDistance = 500;
    private float yellowRayLine;
    private CreatureController parentController;

    private void Start()
    {
        parentController = GetComponentInParent<CreatureController>();
    }

    void Update()
    {
        yellowRayLine = parentController.floatingHeight;
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit raycastToPlatform;
        if (Physics.Raycast(ray, out raycastToPlatform, maxRayDistance, RaycastHitLayer))
        {
            if (raycastToPlatform.distance < yellowRayLine)
            {
                Debug.DrawLine(ray.origin, raycastToPlatform.point, Color.green);
            }
            else
            {
                Debug.DrawLine(ray.origin, raycastToPlatform.point, Color.yellow);
            }
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * yellowRayLine, Color.red);
        }
        distanceToPlatformInfo = raycastToPlatform.distance;
    }
}
