using Anthill.AI;
using Damien;
using UnityEngine;

namespace JonathonMiles
{


    public class NavSensor : MonoBehaviour, ISense
    {
        public FOV fov;
        public Transform playerTarget;
        public Transform itemTarget;

        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            FOVsearch();
            aWorldState.BeginUpdate(aAgent.planner);
            aWorldState.Set("Found Item", false);
            aWorldState.Set("Move To Item", false);
            aWorldState.Set("Collect Item", false);
            aWorldState.Set("See Player", playerTarget);
            aWorldState.Set("Retreat", false);
            aWorldState.Set("Deposit Item", false);
            aWorldState.Set("Move To Deposit", false);
            aWorldState.Set("Has Target", aAgent.GetComponent<NavMain>().currentTarget != null);
            aWorldState.Set("Arrived At Target", false);
            aWorldState.EndUpdate();
        }

        public void FOVsearch()
        {
            if (fov.listOfTargets.Count > 0)
            {
                foreach (GameObject target in fov.listOfTargets)
                {
                    if (fov.targets.Equals("Player"))
                    {
                        float distance = Vector3.Distance(transform.position, target.transform.position);
                        if (distance < 30f)
                        {
                            playerTarget = target.transform;
                        }
                        else
                        {
                            playerTarget = null;
                        } 
                        
                    }

                    if (fov.targets.Equals("Item"))
                    {
                        float distance = Vector3.Distance(transform.position, target.transform.position);
                        if (distance < 30f)
                        {
                            itemTarget = target.transform;
                        }
                        else
                        {
                            itemTarget = null;
                        } 
                    }
                    
                }
            }
            else
            {
                playerTarget = null;
                itemTarget = null;
            }
        }

    }
}

