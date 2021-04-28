using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace AJ
{
    public class CubeShader : NetworkBehaviour
    {
        public Renderer renderer;

        public Texture tex;
        // Start is called before the first frame update
        void Start()
        {
            if (isServer)
            {
                renderer.material.SetTexture("_Texture2D", tex);
            }
        }
    }
}

