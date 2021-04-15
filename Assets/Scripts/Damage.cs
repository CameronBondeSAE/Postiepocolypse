using System;
using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using UnityEngine;
using UnityEngine.Serialization;

public class Damage : MonoBehaviour
{
     public int damageAmount;
     public List<GameObject> inCollider;

     private void Start()
     {
          
     }

     private void FixedUpdate()
     {
          //this loop goes through all objects in the list and deals damage to them
          foreach (var x in inCollider)
          {
               x.GetComponent<Health>().DoDamage(damageAmount, Health.DamageType.Normal);
                    //Debug.Log("Damaging 10 Points to " + inCollider.Count + " items");
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
