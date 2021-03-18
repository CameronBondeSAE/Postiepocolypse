using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace RileyMcGowan
{
    public class Inactive : AntAIState
    {
        public override void Enter()
        {
            base.Enter();
            Finish();
        }

        //private Renderer parentRenderer;
        private void Start()
        {
            //parentRenderer = GetComponentInParent<Renderer>();
            //parentRenderer.material.SetColor("Crimson Red", Color.red);
        }

        private void OnDisable()
        {
            //parentRenderer.material.SetColor("Crimson Red", Color.grey);
        }
    }
}