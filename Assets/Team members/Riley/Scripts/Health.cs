using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

//Namespace use cause why not keep it out of the way of other components
namespace RileyMcGowan
{
    public class Health : NetworkBehaviour
    {
        [Tooltip("Starting Health between 1-100 is reasonable.")]
        public float startingHealth;

        [Tooltip("Expected to be the same as startingHealth on start. If no value set default 100.")]
        public float maxHealth;
        [SyncVar]
        [Tooltip("This is current health, do not edit unless for testing.")]
        public float currentHealth;
        
        [Tooltip("Toggle on to make object invincible (not die).")]
        public bool invincible;
        
        //Events for recognising
        public event Action<Health> deathEvent;
        public event Action<Health, float, DamageType> damagedEvent;
        public event Action<Health> healedEvent;

        //So we can check if health changed
        private float previousHealth;
        
        void Start()
        {
            ResetStartingHealth();
            if (maxHealth <= 0)
            {
                maxHealth = 100;
            }
        }
        
        public enum DamageType
        {
            Normal,
            Poison,
            Energy
        }

        void FixedUpdate()
        {
            //Did the value of health change in the last update
            if (Math.Abs(currentHealth - previousHealth) > .001f)
            {
                //If so check health variables
                if (currentHealth <= 0 && invincible != true)
                {
                    //Has health hit 0
                    currentHealth = 0;
                    DestroyObject();
                }
                if (currentHealth > maxHealth)
                {
                    //Is health over the maximum
                    currentHealth = maxHealth;
                }
            }
            previousHealth = currentHealth;
        }
        
        /// DO DAMAGE AND HEALING ///
        //DoDamage function to record damage then apply it
        public void DoDamage(float damageDealt, DamageType damageType)
        {
            if (invincible != true)
            {
                currentHealth -= damageDealt;
                damagedEvent?.Invoke(this, damageDealt, damageType);
            }
        }
        //DoHeal function to apply healing to the object until max
        public void DoHeal(float healApply)
        {
            if (currentHealth + healApply <= maxHealth && invincible != true)
            {
                currentHealth += healApply;
                healedEvent?.Invoke(this);
            }
            else
            {
                if (currentHealth < maxHealth && invincible != true)
                {
                    currentHealth = maxHealth;
                    healedEvent?.Invoke(this);
                }
            }
        }
        
        //Simple add and remove max health
        public void DecreaseMaxHealth(float removeHealthMax)
        {
            maxHealth -= removeHealthMax;
        }
        public void IncreaseMaxHealth(float addHealthMax)
        {
            maxHealth += addHealthMax;
        }
        /// DO DAMAGE AND HEALING ///

        //
        public void ResetStartingHealth()
        {
            if (startingHealth == 0)
            {
                startingHealth = 100;
            }
            currentHealth = startingHealth;
        }
        
        //Separate health trigger for editor and functionality
        public void ResetMaxHealth()
        {
            currentHealth = maxHealth;
        }
        
        //Separated death function for editor
        public void DestroyObject()
        {
            deathEvent?.Invoke(this);
        }

        /// Modular functions to rip out if needed ///
        public void DoPoison(float totalDamage, float damageIntervals, float damageDelay)
        {
            StartCoroutine(PoisonedDOT(totalDamage, damageIntervals, damageDelay));
        }

        IEnumerator PoisonedDOT(float damageToDeal, float damageIntervals, float intervalDelay)
        {
            //Split the damage to be delt across the intervals
            float intervalDamage = damageToDeal / damageIntervals;
            
            for (float i = 0; i < damageIntervals; i++)
            {
                this.DoDamage(intervalDamage, DamageType.Poison);
                yield return new WaitForSeconds(intervalDelay);
            }
        }
    }
}