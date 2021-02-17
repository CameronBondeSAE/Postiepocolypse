﻿using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

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
                    Timer = Random.Range(MinTime, MaxTime);
                }
            }
        }
    }
}

