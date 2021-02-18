using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AJ
{
    public class FlickerLightAJ : NetworkBehaviour
    {

        public Light _light;

        public float MinTime;

        public float MaxTime;

        public float Timer;
        // Start is called before the first frame update
        void Start()
        {
            Timer = Random.Range(MinTime, MaxTime);
        }

        // Update is called once per frame
        void Update()
        {
            if (isServer)
            {
                FlickerLight();
            }

            if (InputSystem.GetDevice<Keyboard>().tKey.wasPressedThisFrame)
            {
                CmdFirstCommand();
            }
        }

        [Command(ignoreAuthority = true)]
        void CmdFirstCommand()
        {
            Debug.Log("Client command sent!");
        }

        [ClientRpc]
        void RpcSetLight(bool lightEnabled)
        {
            _light.enabled = lightEnabled;
        }

        void FlickerLight()
        {
            if (isServer)
            {
                if (Timer > 0)
                {
                    Timer -= Time.deltaTime;
                }

                if (Timer <= 0)
                {
                    _light.enabled = !_light.enabled; 
                    RpcSetLight(_light.enabled);
                    Timer = Random.Range(MinTime, MaxTime);
                }
            }
        }
    }
}

