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
            antAIAgent.SetGoal("Patrol");
            Debug.Log(playerLayer);
            playerLayer = 8;
        }

        private void Update()
        {
            //CheckingForPlayers();
        }

        /*public void CheckingForPlayers()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
            if (hitInfo.collider != null)
            {
                Debug.DrawLine(transform.position,hitInfo.point);
                //TODO this will break if player has more than one layer
                if (hitInfo.collider.gameObject.GetComponent<PlayerBase>()) 
                {
                    playerTarget = hitInfo.transform;
                    playerTarget.position = hitInfo.transform.position;
                    Debug.Log("I See You");
                }
                else
                {
                    playerTarget = null;
                }
            }
            else
            {
                playerTarget = null;
            }
        }*/
        
    }
}
