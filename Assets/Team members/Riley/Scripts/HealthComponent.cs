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

        //Allows us to call the object to die
        public event Action<HealthComponent> killObject;

        void Start()
        {
            //Sync our health
            health = startingHealth;
        }

        //Take a DoDamage Function to do damage, then take the value as an int.
        public void DoDamage(int damageDelt)
        {
            //Minus the damage from before
            health -= damageDelt;
        }
        void Update()
        {
            //If we take damage that makes the objects health 0 then invoke the event
            if (health <= 0)
            {
                if (killObject != null)
                {
                    killObject.Invoke(this);
                }
            }
        }
    }
}
