using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace AlexM
{
    public class NetworkingTest : NetworkBehaviour
    {

        private float count;
        private bool DoCount = true;

        public Light[] lights;

        public bool lightState;
        public bool StopLoop;
        private void Start()
        {
            if (isServer)
            {
                //InvokeRepeating("RpcLightState", 1f, 1f);
                StartCoroutine(Repeater());
            }
        }

    #region ServerStuff

        void ToggleLightState()
        {
            if (isServer)
            {
                foreach (var _light in lights)
                {
                    if (_light.gameObject.activeSelf)
                    {
                        _light.gameObject.SetActive(false);
                    }
                    else
                    {
                        _light.gameObject.SetActive(true);
                    }
                }
            } 
        }

    #endregion

    #region ClientStuff

        [ClientRpc]
        void RpcLightState(bool _lightState)
        {
            foreach (var _light in lights)
            {
                _light.gameObject.SetActive(_lightState);
            }
        }

    #endregion

        IEnumerator Repeater()
        {
            while (true)
            {
                lightState = true;
                RpcLightState(lightState);
                yield return new WaitForSeconds(0.5f);
                lightState = false;
                RpcLightState(lightState);
                yield return new WaitForSeconds(0.5f);
                if (StopLoop)
                {
                    break;
                }
            }
        }
        
        IEnumerator Count(float time)
        {
            if (DoCount)
            {
                count++;
                Debug.Log("P: " + count);
                DoCount = false;
            }

            yield return new WaitForSeconds(time);
            DoCount = true;
            StartCoroutine(Count(1f));
        }
    }
}
