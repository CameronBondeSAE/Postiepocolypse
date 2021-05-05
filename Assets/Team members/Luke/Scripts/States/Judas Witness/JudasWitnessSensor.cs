using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Luke
{
    public class JudasWitnessSensor : MonoBehaviour, ISense
    {
        public JudasWitnessModel judasWitnessModel;
        public FOV fov;
        public List <GameObject> playerTargets;

        public void Start()
        {
            judasWitnessModel = GetComponent<JudasWitnessModel>();
            fov = GetComponent<FOV>();
        }

        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            aWorldState.BeginUpdate(aAgent.planner);
            {
                lookForPlayers();

                aWorldState.Set("playerFound", judasWitnessModel.currentPlayerTarget != null);
            }
            aWorldState.EndUpdate();
        }

        public void lookForPlayers()
        {
            if (fov.listOfTargets.Count > 0)
            {
                foreach (GameObject playerTarget in fov.listOfTargets)
                {
                    float distance = Vector3.Distance(transform.position, playerTarget.transform.position);

                    if (playerTarget != judasWitnessModel.currentPlayerTarget)
                    {
                       if (distance < fov.viewRadius)
                       {
                           judasWitnessModel.currentPlayerTarget = playerTarget;
                       } 
                    }
                    if (distance > fov.viewRadius)
                    {
                        playerTargets.Remove(playerTarget);
                        judasWitnessModel.currentPlayerTarget = null;
                    }
                }
            }

            if (judasWitnessModel.currentPlayerTarget != null)
            {
                float distanceFromCurrentPlayer =
                    Vector3.Distance(transform.position, judasWitnessModel.currentPlayerTarget.transform.position);
                
                if (distanceFromCurrentPlayer > fov.viewAngle)
                {
                    playerTargets.Remove(judasWitnessModel.currentPlayerTarget);
                    judasWitnessModel.currentPlayerTarget = null;
                }
            }
            
        }
    }
}
