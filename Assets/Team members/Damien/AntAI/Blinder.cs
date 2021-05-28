using System.Collections;
using Anthill.AI;
using Mirror;
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

        public int flashSoundNumber;
        public int screamSoundNumber;
        
        public bool targetsInView;

        public AudioSource flashSoundsSource;
        public AudioClip[] flashSoundsArray;

        public AudioSource screamSoundsSource;
        public AudioClip[] screamSoundsArray;
        
        public PatrolManager patrolManager;
        public NavMeshAgent navMeshAgent;

        private int destinationNumber;

        private BlinderFunctions _blinderFunctions;

        // Start is called before the first frame update
		public override void OnStartServer()
		{
			base.OnStartServer();

			if(isServer)
            {
                BlinderFunctions _blinderFunctions = GetComponent<BlinderFunctions>();
                navMeshAgent = owner.GetComponent<NavMeshAgent>();
                patrolManager = FindObjectOfType<PatrolManager>();
                antAIAgent.SetGoal("Disorient Target");
                flashSoundsArray = Resources.LoadAll<AudioClip>("FlashSounds");
                screamSoundsArray = Resources.LoadAll<AudioClip>("BlinderScream");
                //_blinderFunctions.ResetStates();  This nulls
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

        public void PlayScream()
        {
            if (isClient)
            {
                screamSoundNumber = Random.Range(0, 3);
                screamSoundsSource.PlayOneShot((screamSoundsArray[screamSoundNumber]));
            }
            
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

        public void ResetStatesHere()
        {
            if (isClient)
            {
                _blinderFunctions.ResetStates();
            }
        }

        public void FlashPlayerHere()
        {
            if (isClient)
            {
                _blinderFunctions.RpcFlashPlayer();
            }
        }

        public void PlayerFlashSoundHere()
        {

            if (isClient)
            {
                _blinderFunctions.PlayFlashSound();
            }
        }
    }
}

