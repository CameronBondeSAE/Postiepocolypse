using System;
using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using UnityEngine;

public class Damage : MonoBehaviour
{
     public SphereCollider sphere;
     public float sphereRadius;

     public List<GameObject> inCircle;

     private void Start()
     {
          sphere = GetComponent<SphereCollider>();
          sphere.radius = sphereRadius;
     }

     private void FixedUpdate()
     {
          foreach (var x in inCircle)
          {
               x.GetComponent<Health>().DoDamage(1);
                    Debug.Log("Damaging 10 Points to " + inCircle.Count + " items");
          }
     }

     private void OnTriggerEnter(Collider other)
     {
          if(other.transform.GetComponent<Health>() != null)
          {
               Debug.Log("Health object found, adding to list");
               inCircle.Add(other.gameObject);
          }
     }
}
