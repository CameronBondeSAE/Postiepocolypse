using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class TorchController : NetworkBehaviour
{
    public Light flashlight;
    public bool lightOn = false;
    
    

    // We need to make this ONLY run on the player you own, not ALL players on the clients
    public void FlashLightInput(InputAction.CallbackContext obj)
    {
        if (isLocalPlayer)
        {
            if (obj.performed)
            {
                CmdToggleLight();
            }
        }
    }

// Command function. Client to Server, telling it you changed the state of the torch
    [Command]
    void CmdToggleLight()
    {
        
        Debug.Log("Flashlight button pressed");
        
        if (lightOn)
        {
            lightOn = false;
        }
        else if (!lightOn)
        {
            lightOn = true;
        }
        
        RpcSetTorchState(lightOn);
    }

    [ClientRpc]
    public void RpcSetTorchState(bool state)
    {
        if (flashlight == null)
        {
            Debug.Log("Please add the players light source to Cam_MouseLook");
            return;
        }
        flashlight.enabled = state;
    }
}


