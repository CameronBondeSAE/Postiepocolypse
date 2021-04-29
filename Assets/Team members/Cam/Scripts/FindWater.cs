using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using ZachFrench;
using Random = UnityEngine.Random;

public class FindWater : MonoBehaviour
{
    public LayerMask layerMask;
    public int numberOfTargets;
    private PatrolManager patrolManager;
    public PatrolPoint prefab;
    public int size = 20;

    public RaycastHit[] raycastHits;

    private void Start()
    {
        Find();
    }

    [Button("Find water")]
    void Find()
    {
        patrolManager = FindObjectOfType<PatrolManager>();
        if (patrolManager == null)
        {
            Debug.LogWarning("Needs Patrol Manager in scene");
            return;
        }

        int maxTries = 1000;
        int currentTries = 0;

        while (patrolManager.waterTargets.Count < numberOfTargets)
        {
            RaycastHit hitInfo;

            float x = Random.Range(-size, size);
            float z = Random.Range(-size, size);

            Ray ray = new Ray(transform.position + new Vector3(x, 1000, z), Vector3.down);

            // Physics.Raycast(new Ray(transform.position + new Vector3(x,1000,z), Vector3.down), out hitInfo, 99999, layerMask, QueryTriggerInteraction.Collide);
            raycastHits = Physics.RaycastAll(ray, 99999, layerMask, QueryTriggerInteraction.Collide);
            // raycastHits = Physics.RaycastAll(ray, 99999);
            int waterIndex = 0;
            int groundIndex = 0;


            if (raycastHits.Length > 1) // Only interested in hitting water AND the ground under it, so at least 2 hits.
            {
                if (raycastHits[0].collider.GetComponent<Water>() && raycastHits[1].collider.GetComponent<Terrain>() ||
                    raycastHits[1].collider.GetComponent<Water>() && raycastHits[0].collider.GetComponent<Terrain>())
                {
                    if (raycastHits[0].collider.GetComponent<Terrain>())
                    {
                        groundIndex = 0;
                        waterIndex = 1;
                    }
                    else if (raycastHits[0].collider.GetComponent<Water>())
                    {
                        groundIndex = 1;
                        waterIndex = 0;
                    }
                }
                else
                {
                    // Didn't hit either
                    return;
                }


                Debug.DrawLine(ray.origin, raycastHits[waterIndex].point, Color.green, 10f);

                PatrolPoint patrolPoint = Instantiate(prefab, raycastHits[waterIndex].point, Quaternion.identity);

                if (!(patrolManager is null))
                {
                    patrolManager.waterTargets.Add(patrolPoint);
                }
                else
                {
                    Debug.LogWarning("Needs Patrol Manager in scene");
                }

                // Check as the PatrolPoint might not SPECIFICALLY be a WaterTarget inheritor
                WaterTarget waterTarget = (patrolPoint as WaterTarget);
                if (!(waterTarget is null))
                    waterTarget.depth = raycastHits[waterIndex].point.y - raycastHits[groundIndex].point.y;
            }
            else
            {
                Debug.DrawLine(ray.origin, raycastHits[groundIndex].point, Color.red, 10f);
            }

            currentTries++;
            if (currentTries > maxTries)
            {
                Debug.LogWarning("Tried A LOT to find water. Probably too much");
                break;
            }
        }
    }
}