using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using Damien;
using Mirror;
using UnityEngine;
/*
public class BlinderFunctions : NetworkBehaviour
{
   private Blinder mainScript;
   private AudioSource flashSoundsSource;
   private AudioClip[] flashSoundsArray;
   
   [ClientRpc]
   public void RpcFlashPlayer()
   {
      if (isClient)
      {
         mainScript = GetComponent<Blinder>();
         StartCoroutine(FlashPlayer());
         Debug.Log("CoroutineStarted");
      }
   }
   /*IEnumerator FlashPlayer()
   {
      if (isClient)
      {
         Light flash = mainScript.flash;
         float flashBrightness = mainScript.flashBrightness;
         float flashOffBrightness = mainScript.flashOffBrightness;
         mainScript.FlashPlayerHere();
         flash.intensity = flashBrightness;
         
         yield return new WaitForSeconds(.1f);
         flash.intensity = flashOffBrightness;
         Debug.Log("FlashChanged");
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
         RpcFlashPlayer();
         ResetStates();
      }
   }*/
   /*
   
   public void ResetStates()
   {
      if (isClient)
      {
         Blinder mainScript = GetComponent<Blinder>();
         mainScript.ResetStatesHere();
         mainScript.target = null;
         mainScript.energyTarget = null;
         AntAIAgent antAIAgent = mainScript.antAIAgent;
         antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
         antAIAgent.worldState.Set("Light Energy is Full", false);
         antAIAgent.worldState.Set("Target Blinded", false);
         antAIAgent.worldState.Set("Close to Target", false);
         antAIAgent.worldState.Set("Arrived at Energy", false);
         antAIAgent.worldState.Set("Target in View Range", false);
         antAIAgent.worldState.EndUpdate();
      }
   }*/
  /* 
   public void PlayFlashSound()
   {
      if (isClient)
      {
         //this.mainScript.PlayerFlashSoundHere();
         Blinder mainScript = GetComponent<Blinder>();
         int flashSoundNumber = mainScript.flashSoundNumber;
         flashSoundNumber = Random.Range(0, 4);
         flashSoundsSource.PlayOneShot(flashSoundsArray[flashSoundNumber]);
      }
   }
}*/




