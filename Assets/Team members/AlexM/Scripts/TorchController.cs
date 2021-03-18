using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class TorchController : NetworkBehaviour
{
    public Light flashlight;


    public void Awake()
    {
        flashlight = GetComponent<Light>();
    }

    public void FlashLightInput(InputAction.CallbackContext obj)
    {
        //if (isLocalPlayer)
        {
            if (obj.performed)
            {
                ToggleLight();
            }
        }
    }
    void ToggleLight()
    {
        //if (isServer)
        {
            if (flashlight == null)
            {
                Debug.Log("Please add the players light source to Cam_MouseLook");
                return;
            }
            
            Debug.Log("Flashlight button pressed");
            
            if (flashlight.enabled)
            {
                flashlight.enabled = false;
            }
            else if (!flashlight.enabled)
            {
                flashlight.enabled = true;
            }
        }
    }
}
