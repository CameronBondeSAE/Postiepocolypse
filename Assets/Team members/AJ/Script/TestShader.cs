using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AJ
{
    public class TestShader : MonoBehaviour
    {
        //private Renderer renderer;
        //public Gradient gradient;
        //[SerializeField] private Material material;
        //Color lerpedColor = Color.white;
        
        /// <summary>
        ///
        /// </summary>
        public float FadeDuration = 1f;
        public Color Color1 = Color.green;
        public Color Color2 = Color.magenta;

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
            startColor = Color1;
            endColor = Color2;
        }

        // Update is called once per frame
        void Update()
        {
            var ratio = (Time.time - lastColorChangeTime) / FadeDuration;
            ratio = Mathf.Clamp01(ratio);
            material.color = Color.Lerp(startColor, endColor, ratio);
            

            if (ratio == 1f)
            {
                lastColorChangeTime = Time.time;

                // Switch colors
                var temp = startColor;
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
}

