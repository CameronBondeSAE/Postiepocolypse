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
        public int startingHealth;

        [Tooltip("Expected to be the same as startingHealth on start. If no value set default 100.")]
        public int maxHealth;
        [SyncVar]
        [Tooltip("This is current health, do not edit unless for testing.")]
        public int currentHealth;
        
        [Tooltip("Toggle on to make object invincible (not die).")]
        public bool invincible;
        
        //Events for recognising
        public event Action<Health> deathEvent;
        public event Action<Health, int, DamageType> damagedEvent;
        public event Action<Health> healedEvent;
        
        
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

        void Update()
        {
            //If we take damage that makes the objects health 0 then invoke death
            if (currentHealth <= 0 && invincible != true)
            {
                currentHealth = 0;
                DestroyObject();
            }
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
        
        /// DO DAMAGE AND HEALING ///
        //DoDamage function to record damage then apply it
        public void DoDamage(int damageDealt, DamageType damageType)
        {
            if (invincible != true)
            {
                currentHealth -= damageDealt;
                damagedEvent?.Invoke(this, damageDealt, damageType);
            }
        }
        //DoHeal function to apply healing to the object until max
        public void DoHeal(int healApply)
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
        public void DecreaseMaxHealth(int removeHealthMax)
        {
            maxHealth -= removeHealthMax;
        }
        public void IncreaseMaxHealth(int addHealthMax)
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
        public void DoPoison(int totalDamage, int damageIntervals, int damageDelay)
        {
            StartCoroutine(PoisonedDOT(totalDamage, damageIntervals, damageDelay));
        }

        IEnumerator PoisonedDOT(int damageToDeal, int damageIntervals, int intervalDelay)
        {
            //Split the damage to be delt across the intervals
            int intervalDamage = damageToDeal / damageIntervals;
            
            for (int i = 0; i < damageIntervals; i++)
            {
                this.DoDamage(intervalDamage, DamageType.Poison);
                yield return new WaitForSeconds(intervalDelay);
            }
        }
    }
}