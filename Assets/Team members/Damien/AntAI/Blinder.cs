using System;
using System.Collections;
using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class Blinder : MonoBehaviour
    {
        public GameObject owner;
        public AntAIAgent antAIAgent;
        public GameObject target;
        public GameObject energyTarget;
        public Light flash;
        public float flashBrightness = 200000000f;
        public float flashOffBrightness = 0.5f;
        public bool targetsInView;


        // Start is called before the first frame update
        void Start()
        {
            antAIAgent.SetGoal("Disorient Target");
            ResetStates();
        }

        private void Update()
        {
            if (GetComponent<FOV>().listOfTargets.Count > 0)
            {
                targetsInView = true;
            }
            else
            {
                targetsInView = false;
            }

            if (targetsInView)
            {
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("Target in View Range", true);
                antAIAgent.worldState.EndUpdate();
            }

            if (!targetsInView)
            {
                antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                antAIAgent.worldState.Set("Target in View Range", false);
                antAIAgent.worldState.EndUpdate();
            }
        }


        public void ResetStates()
        {
            target = null;
            energyTarget = null;
            antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
            antAIAgent.worldState.Set("Light Energy is Full", false);
            antAIAgent.worldState.Set("Target Blinded", false);
            antAIAgent.worldState.Set("Close to Target", false);
            antAIAgent.worldState.Set("Arrived at Energy", false);
            antAIAgent.worldState.Set("Target in View Range", false);
            antAIAgent.worldState.EndUpdate();
        }

        IEnumerator FlashPlayer()
        {
            yield return new WaitForSeconds(2f);
            flash.intensity = flashBrightness;
            yield return new WaitForSeconds(.1f);
            flash.intensity = flashOffBrightness;
            
            yield return new WaitForSeconds(.1f);
            flash.intensity = flashBrightness;
            yield return new WaitForSeconds(.1f);
            flash.intensity = flashOffBrightness;
            
            yield return new WaitForSeconds(.1f);
            flash.intensity = flashBrightness;
            yield return new WaitForSeconds(.1f);
            flash.intensity = flashOffBrightness;
            
            ResetStates();
            
        }
    }
}