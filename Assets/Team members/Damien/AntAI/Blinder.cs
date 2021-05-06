using System.Collections;
using Anthill.AI;
using Mirror;
using UnityEngine;
using ZachFrench;

namespace Damien
{
    public class Blinder : NetworkBehaviour
    {
        public GameObject owner;
        
        public AntAIAgent antAIAgent;
        
        public GameObject target;
        public GameObject energyTarget;
        
        public Light flash;
        
        public float flashBrightness = 200000000f;
        public float flashOffBrightness = 0.5f;

        private int flashSoundNumber;
        private int screamSoundNumber;
        
        public bool targetsInView;

        public AudioSource flashSoundsSource;
        public AudioClip[] flashSoundsArray;

        public AudioSource screamSoundsSource;
        public AudioClip[] screamSoundsArray;
        
        public PatrolManager patrolManager;


        // Start is called before the first frame update
        void Start()
        {
            if (isServer)
            {
                antAIAgent.SetGoal("Disorient Target");
                flashSoundsArray = Resources.LoadAll<AudioClip>("FlashSounds");
                screamSoundsArray = Resources.LoadAll<AudioClip>("BlinderScream");
                ResetStates();
            }
            else
            {
                antAIAgent.enabled = false;
            }
            
        }
        private void Update()
        {
            if (isServer)
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
        }

        public void PlayFlashSound()
        {
            flashSoundNumber = Random.Range(0, 4);
            flashSoundsSource.PlayOneShot(flashSoundsArray[flashSoundNumber]);
        }

        public void PlayScream()
        {
            screamSoundNumber = Random.Range(0, 3);
            screamSoundsSource.PlayOneShot((screamSoundsArray[screamSoundNumber]));
        }
        
        public void Idle()
        {
            if (isServer)
            {
                if (patrolManager == null)
                {
                    patrolManager = FindObjectOfType<PatrolManager>();
                    if (patrolManager == null)
                    {
                        return;
                    }
                }
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
            //yield return new WaitForSeconds(2f);
            flash.intensity = flashBrightness;
            PlayFlashSound();
            yield return new WaitForSeconds(.1f);
            flash.intensity = flashOffBrightness;

            yield return new WaitForSeconds(.1f);
            flash.intensity = flashBrightness;
            yield return new WaitForSeconds(.1f);
            flash.intensity = flashOffBrightness;

            yield return new WaitForSeconds(.1f);
            flash.intensity = flashBrightness;
            yield return new WaitForSeconds(.2f);
            flash.intensity = flashOffBrightness;

            yield return new WaitForSeconds(.1f);
            flash.intensity = flashBrightness;
            yield return new WaitForSeconds(.1f);
            flash.intensity = flashOffBrightness;

            yield return new WaitForSeconds(.1f);
            flash.intensity = flashBrightness;
            yield return new WaitForSeconds(.2f);
            flash.intensity = flashOffBrightness;
            ResetStates();
        }

        [ClientRpc]
        public void RpcFlashPlay()
        {
            StartCoroutine(FlashPlayer());
        }
    }
}