using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

public class PlayerHealthDemo : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<RileyMcGowan.Health>().deathEvent += Death;
        GetComponent<RileyMcGowan.Health>().damagedEvent += Damaged;
        GetComponent<RileyMcGowan.Health>().healedEvent += Healed;
    }
    private void OnDisable()
    {
        GetComponent<RileyMcGowan.Health>().deathEvent -= Death;
        GetComponent<RileyMcGowan.Health>().damagedEvent += Damaged;
        GetComponent<RileyMcGowan.Health>().healedEvent += Healed;
    }
    
    private void Death(RileyMcGowan.Health health)
    {
        Destroy(gameObject);
    }
    private void Damaged(RileyMcGowan.Health health)
    {
        Debug.Log("I'VE BEEN HIT!");
    }
    private void Healed(RileyMcGowan.Health health)
    {
        Debug.Log("Much better.");
    }
}
