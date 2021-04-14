using System;
using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using UnityEngine;

public class CreatureDamage : MonoBehaviour
{
    private int damageDelt = 10;
    private GameObject parentTarget;
    public bool haveDamaged;

    private void Start()
    {
        parentTarget = GetComponentInParent<CreatureController>().target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != null)
        {
            Health healthComp = other.GetComponent<Health>();
            healthComp.DoDamage(damageDelt, Health.DamageType.Normal);
            StartCoroutine(DamageHasBeenDelt());
        }
    }

    IEnumerator DamageHasBeenDelt()
    {
        haveDamaged = true;
        yield return new WaitForSeconds(5);
        haveDamaged = false;
    }
    
}
