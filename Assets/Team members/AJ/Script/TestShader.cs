using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace AJ
{
    public class TestShader : NetworkBehaviour
    {
        public float FadeDuration = 1f;
        public Color Color1;
        public Color Color2;
        

        private Color startColor;
        private Color endColor;
        private float lastColorChangeTime;

        private Material material;
        
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
            }
        }
        
        [ClientRpc]
        public void RpcChangeColour(Color colour)
        {
            material.color = colour;
        }
    }
    
}

