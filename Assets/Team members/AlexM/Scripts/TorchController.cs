using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class TorchController : NetworkBehaviour
{
    public Light flashlight;


    public void ToggleLight()
    {
        if (isServer)
        {
            if (flashlight == null)
            {
                Debug.Log("Please add the players light source to Cam_MouseLook");
                return;
            }

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

    public void FlashLightInput(InputAction.CallbackContext obj)
    {
        if (isLocalPlayer)
        {
            if (obj.performed)
            {
                ToggleLight();
            }
        }
    }
}
