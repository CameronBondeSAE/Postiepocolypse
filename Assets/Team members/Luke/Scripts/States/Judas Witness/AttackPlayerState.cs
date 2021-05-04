using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anthill.AI;
using Damien;
using UnityEngine.AI;

namespace Luke
{
    /// <summary>
    /// Change VFX colour to slowly change to red instead of blue + DO DAMAGE
    /// </summary>
    public class AttackPlayerState : AntAIState
    {
        public GameObject owner;
        public NavMeshAgent navMeshAgent;
        public JudasWitnessModel judasWitnessModel;
        public AntAIAgent antAIAgent;
        
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            
            owner = aGameObject;
            navMeshAgent = owner.GetComponent<NavMeshAgent>();
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
            antAIAgent = owner.GetComponent<AntAIAgent>();
        }

        public override void Enter()
        {
            base.Enter();
        }
    }
}
