﻿using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CubeShader : NetworkBehaviour
{
    public Renderer renderer;

    public Texture tex;
    // Start is called before the first frame update
    void Start()
    {
        renderer.material.SetTexture("_Texture2D", tex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
