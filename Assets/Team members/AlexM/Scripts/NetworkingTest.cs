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


        private void Start()
        {
            if (isServer)
            {
                InvokeRepeating("rpcToggleLight", 1f, 1f);
            }
        }

        [ClientRpc]
        void rpcToggleLight()
        {
            foreach (var light in lights)
            {
                if (light.gameObject.activeSelf)
                {
                    light.gameObject.SetActive(false);
                }
                else
                {
                    light.gameObject.SetActive(true);
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
