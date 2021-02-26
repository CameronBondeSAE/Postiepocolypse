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

        [Tooltip("Expected to be the same as startingHealth on start.")]
        public int maxHealth;

        [Tooltip("This is current health, do not edit unless for testing.")]
        public int health;
        
        [Tooltip("Toggle on to make object invinsible (not die).")]
        public bool invincible;
        
        //Allows us to call the object to die
        public event Action<HealthComponent> killObject;
        void Start()
        {
            StartingHealth();
        }
        void Update()
        {
            //If we take damage that makes the objects health 0 then invoke death
            if (health <= 0 && invincible != true)
            {
                DestroyObject();
            }
        }
        
        /// DO DAMAGE AND HEALING ///
        //DoDamage function to record damage then apply it
        public void DoDamage(int damageDelt)
        {
            if (invincible != true)
            {
                health -= damageDelt;
            }
        }
        //DoHeal function to apply healing to the object
        public void DoHeal(int healApply)
        {
            if (health + healApply <= maxHealth && invincible != true)
            {
                health += healApply;
            }
            else
            {
                if (health < maxHealth && invincible != true)
                {
                    health = maxHealth;
                }
            }
        }

        /// DO DAMAGE AND HEALING ///

        //
        public void StartingHealth()
        {
            health = startingHealth;
        }
        
        //Separate health trigger for editor and functionality
        public void MaxHealth()
        {
            health = maxHealth;
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
