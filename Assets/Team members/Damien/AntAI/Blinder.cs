using System.Collections;
using Anthill.AI;
using Mirror;
using Mono.CecilX.Cil;
using UnityEngine;
using UnityEngine.AI;
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
        public NavMeshAgent navMeshAgent;

        private int destinationNumber;


        // Start is called before the first frame update
		public override void OnStartServer()
		{
			base.OnStartServer();

			if(isServer)
            {
                navMeshAgent = owner.GetComponent<NavMeshAgent>();
                patrolManager = FindObjectOfType<PatrolManager>();
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
            if (isClient)
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

        public void SetDestination()
        {
            if (isClient)
            {
                destinationNumber = Random.Range(0, patrolManager.paths.Count);
                navMeshAgent.SetDestination(patrolManager.paths[destinationNumber].transform.position);
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
            if (isClient)
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
            if (isClient)
            {
                yield return new WaitForSeconds(.5f);
                flash.intensity = flashBrightness;
                PlayFlashSound();
                yield return new WaitForSeconds(.5f);
                FlashOff();
                yield return new WaitForSeconds(.5f);
                flash.intensity = flashBrightness;
                yield return new WaitForSeconds(.5f);
                FlashOff();
                ResetStates();
            }
        }
        
        public void FlashOff()
        {
            flash.intensity = 0.5f;
            Debug.Log("hello");
        }

        [ClientRpc]
        public void RpcFlashPlay()
        {
            StartCoroutine(FlashPlayer());
        }
    }
}