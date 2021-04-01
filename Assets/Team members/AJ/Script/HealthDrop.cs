using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using TimPearson;
using UnityEngine;

namespace AJ
{
    public class HealthDrop : MonoBehaviour
    {
        public float energy = 5f;
        public float health = 20f;
        public float healthLossRate = 0.01f;

        // Update is called once per frame
        void Update()
        {
            //if (Input.GetKey(KeyCode.A))
            {
                //if energy is less than or = to 0, health takes damage corresponding to the healthLossRate's set stat
                if (energy <= 0)
                {
                    health -= healthLossRate;
                }
                
                //not only is this to prevent the health falling below 0, once health hits 0, it stops counting down
                if (health <= 0)
                {
                    health = 0;
                }
            }
        }
    }
}

