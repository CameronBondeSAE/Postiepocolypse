using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Namespace use cause why not keep it out of the way of other components
namespace HealthComponent
{
    public class HealthComponent : MonoBehaviour
    {
        [Tooltip("Starting Health between 1-100 is reasonable.")]
        public int startingHealth;

        [Tooltip("This is current health, do not edit unless for testing.")]
        public int health;
        
        [Tooltip("Toggle on to make object invinsible (not die).")]
        public bool invincible;
        
        //Allows us to call the object to die
        public event Action<HealthComponent> killObject;
        void Start()
        {
            //Sync our health
            health = startingHealth;
        }
        //DoDamage function to record damage then apply it
        public void DoDamage(int damageDelt)
        {
            if (invincible != true)
            {
                health -= damageDelt;
            }
        }
        void Update()
        {
            //If we take damage that makes the objects health 0 then invoke death
            if (health <= 0 && invincible != true)
            {
                DestroyObject();
            }
        }
        //Separated death function for editor
        public void DestroyObject()
        {
            if (killObject != null)
            {
                killObject.Invoke(this);
            }
        }
    }
}
