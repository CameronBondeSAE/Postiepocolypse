using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace AJ
{
    public class TestShader : NetworkBehaviour
    {
        //private Renderer renderer;
        //public Gradient gradient;
        //[SerializeField] private Material material;
        //Color lerpedColor = Color.white;

        /// <summary>
        ///
        /// </summary>
        ///
        
        
        public float FadeDuration = 1f;
        public Color Color1;
        public Color Color2;
        

        private Color startColor;
        private Color endColor;
        private float lastColorChangeTime;

        private Material material;

        /// <summary>
        ///
        /// </summary>


        // Start is called before the first frame update
        
        void Start()
        {
            material = GetComponent<Renderer>().material;
            if (isServer)
            {
                startColor = Color.green;
                endColor = Color.magenta;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isServer)
            {
                float ratio = (Time.time - lastColorChangeTime) / FadeDuration;
                ratio = Mathf.Clamp01(ratio);
                RpcChangeColour(Color.Lerp(startColor, endColor, ratio));

                

                if (ratio >= 1f)
                {
                    lastColorChangeTime = Time.time;

                    // Switch colors
                    Color temp = startColor;
                    startColor = endColor;
                    endColor = temp;
                }

                /*if (Input.GetButtonDown("Fire1"))
                {
                    material.SetColor("_Color",lerpedColor = Color.Lerp(Color.white, Color.green, Mathf.PingPong(Time.time, 1)));
                    
                }*/
                //renderer.material.SetColor("_Colour", Color.yellow);
                //gradient.Evaluate(0f);
            }
        }
        
        [ClientRpc]
        public void RpcChangeColour(Color colour)
        {
            material.color = colour;
        }
    }
    
}

