using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using RileyMcGowan;
using UnityEngine;
using UnityEngine.AI;

public class AntAIPlannerState : AntAIState
{
    
    protected GameObject owner;
    protected AntAIAgent antAIRef;
    protected NavMeshAgent navMeshRef;
    protected CreatureMain creatureMainRef;
    
    public override void Create(GameObject aGameObject)
    {
        base.Create(aGameObject);
        owner = aGameObject;
        antAIRef = owner.GetComponent<AntAIAgent>();
        navMeshRef = owner.GetComponent<NavMeshAgent>();
        creatureMainRef = owner.GetComponent<CreatureMain>();
    }
}
