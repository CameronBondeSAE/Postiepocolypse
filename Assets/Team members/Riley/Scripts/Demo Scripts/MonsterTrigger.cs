using System;
using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    public int damageAmount;
    public int healAmount;
    private void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<RileyMcGowan.Health>();
        if (health != null)
        {
            health.DoDamage(damageAmount, Health.DamageType.Normal);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var health = other.GetComponent<RileyMcGowan.Health>();
        if (health != null)
        {
            health.DoHeal(healAmount);
        }
    }
}
