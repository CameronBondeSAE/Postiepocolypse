using System;
using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using UnityEngine;

namespace RileyMcGowan
{
    public class CreatureDamage : MonoBehaviour
    {
        private int damageDelt = 10;
        private CreatureMain ownerMain;
        private GameObject parentTarget;
        public bool haveDamaged;

        private void Start()
        {
            ownerMain = GetComponentInParent<CreatureMain>();
        }

        private void Update()
        {
            parentTarget = ownerMain.playerTarget;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Health>() != null && other.gameObject == parentTarget)
            {
                Health healthComp = other.GetComponent<Health>();
                healthComp.DoDamage(damageDelt, Health.DamageType.Normal);
                StartCoroutine(DamageHasBeenDelt());
            }
        }

        IEnumerator DamageHasBeenDelt()
        {
            haveDamaged = true;
            yield return new WaitForSeconds(10);
            haveDamaged = false;
        }

    }
}