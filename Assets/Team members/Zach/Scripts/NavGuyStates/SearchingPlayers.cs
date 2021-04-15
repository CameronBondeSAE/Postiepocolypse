using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace ZachFrench
{

    public class SearchingPlayers : AntAIState
    {
        private GameObject parent;
        public RaycastHit hitInfo;
        public Vector3 rayStart;
        public Collider player;
        private NavMeshAgent NavMeshAgent;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            parent = aGameObject;
            rayStart = parent.transform.position;
            player = new Collider();
            NavMeshAgent = parent.GetComponent<NavMeshAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Found Player");

            Physics.Raycast(new Ray(rayStart, transform.forward),out hitInfo);
            if (hitInfo.collider == player)
            {
                NavMeshAgent.destination = hitInfo.collider.transform.position;
            }
            Finish();
        }
    }
}
