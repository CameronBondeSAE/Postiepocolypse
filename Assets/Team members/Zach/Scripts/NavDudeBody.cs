using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace ZachFrench
{

    public class NavDudeBody : MonoBehaviour
    {
        public PatrolPoint target;

        public Transform playerTarget;

        public AntAIAgent antAIAgent;

        public LayerMask playerLayer;

        private void Start()
        {
            antAIAgent.SetGoal("Is at Position");
            Debug.Log(playerLayer);
        }

        private void Update()
        {
            CheckingForPlayers();
        }

        public void CheckingForPlayers()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
            if (hitInfo.collider != null)
            {
                Debug.DrawLine(transform.position,hitInfo.point);
                if (hitInfo.collider.gameObject.layer == playerLayer) 
                {
                    playerTarget = hitInfo.transform;
                    playerTarget.position = hitInfo.transform.position;
                    Debug.Log("I See You");
                }
            }
        }
        
        
        
    }
}
