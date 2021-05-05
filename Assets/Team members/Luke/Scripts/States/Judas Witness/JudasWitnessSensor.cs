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
        

        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            lookForPlayers();

            aWorldState.BeginUpdate(aAgent.planner);
            {
                aWorldState.Set("playerFound", judasWitnessModel.currentPlayerTarget != null);
                aWorldState.Set("foundResource", judasWitnessModel.waterTargets.Count >= 1);
            }
            aWorldState.EndUpdate();
        }

        public void lookForPlayers()
        {
            judasWitnessModel = GetComponent<JudasWitnessModel>();
            fov = GetComponent<FOV>();
            
            if (fov.listOfTargets.Count > 0)
            {
                foreach (GameObject playerTarget in fov.listOfTargets)
                {
                    float distance = Vector3.Distance(transform.position, playerTarget.transform.position);

                    if (distance < fov.viewRadius)
                    {
                        playerTargets.Add(playerTarget);
                        judasWitnessModel.currentPlayerTarget = playerTarget;
                    }

                    if (distance > fov.viewRadius)
                    {
                        playerTargets.Remove(playerTarget);
                        judasWitnessModel.currentPlayerTarget = null;
                    }
                }
            }
        }
    }
}
