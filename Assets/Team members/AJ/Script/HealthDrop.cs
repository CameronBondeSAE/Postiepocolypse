using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using TimPearson;
using UnityEngine;

namespace AJ
{
    public class HealthDrop : MonoBehaviour
    {
        public Energy Energy;
        public Health Health;
        public float healthLossRate = 0.01f;

        // Update is called once per frame
        void FixedUpdate()
        {
            //if (Input.GetKey(KeyCode.A))
            {
                //if energy is less than or = to 0, health takes damage corresponding to the healthLossRate's set stat
                if (Energy.Amount <= 0)
                {
                    Health.DoDamage(healthLossRate, Health.DamageType.Energy); 
                }
            }
        }
    }
}

