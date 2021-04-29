using System;
using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using UnityEngine;
using UnityEngine.Serialization;
[RequireComponent(typeof(SphereCollider))]
public class Damage : MonoBehaviour
{
     /// <summary>
     /// Script is used to apply damage to any objects that enter the sphere collider. Any object that will deal damage is required to have a sphere collider on it.
     /// You need to select a damage type within the inspector and set a damage amount.
     /// Damage will constantly be applied while objects are within the sphere.
     /// Once an object leaves the sphere they will no longer have damage applied.
     /// If you want to allow for greater damage at the centre of the sphere, enable Damage Over Distance.
     /// </summary>
     
     public int damageAmount;

     public SphereCollider sphereCollider;
     public List<GameObject> inCollider;
     public Health.DamageType damageType;
     public bool damageOverDistance;
     

     private void Start()
     {
          
     }

     private void FixedUpdate()
     {
          //this loop goes through all objects in the list and deals damage to them
          foreach (var x in inCollider)
          {
               if (damageOverDistance)
               {
                    x.GetComponent<Health>().DoDamage((sphereCollider.radius - damageAmount), damageType);
               }
               else
               {
                    x.GetComponent<Health>().DoDamage(damageAmount, damageType);
                    //Debug.Log("Damaging 10 Points to " + inCollider.Count + " items");
               }
              
          }
     }

     private void OnTriggerEnter(Collider other)
     {
          //when an object with health enters the collider it is added to the list
          if(other.transform.GetComponent<Health>() != null)
          {
               inCollider.Add(other.gameObject);
               //Debug.Log("Health object found, adding to list");
          }
     }

     private void OnTriggerExit(Collider other)
     {
          //when an object that has health leaves the collider it is removed from the list 
          if(other.transform.GetComponent<Health>() != null)
          {
               inCollider.Remove(other.gameObject);
               //Debug.Log("Health object left the collider");
          }
     }
     
}
