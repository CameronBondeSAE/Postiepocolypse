using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZachFrench
{
   
   public class Nose : MonoBehaviour
   {
      //Nose Level 1
      //Identifies smell via trigger from sphere collider in smell 


      public Vector3 target;

      //Smelling takes Vector3 from the Smell script and gives it to the nose via the target vector3 
      //This allows for the Vector3 to be accessed by the monsters code
      public void Smelling(Vector3 target)
      {
         Debug.Log("Found Target!");
         this.target = target;
      }
      
      
   }
}
