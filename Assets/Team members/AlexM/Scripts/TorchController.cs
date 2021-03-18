using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TorchController : MonoBehaviour
{
    public Light flashlight;


    public void ToggleLight(bool state)
    {
        if (state)
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
}
