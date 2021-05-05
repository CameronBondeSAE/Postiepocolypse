using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace ZachFrench
{


    public class VFXTesting : MonoBehaviour
    {
        public VisualEffect visualEffect;
        public GradientSwitch stateSwitch;
        public ParticleCapacity particleSwitch;

        public enum GradientSwitch
        {
            Calm,
            Angry,
            LowEnergy
        }
        public enum ParticleCapacity
        {
            Normal,
            Angry
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            visualEffect.SetInt("SwitchGradient", (int) stateSwitch);
        }

        void AngerParticle()
        {
            visualEffect.SetInt("Capacity Switch", (int) particleSwitch);
        }

    }
}
