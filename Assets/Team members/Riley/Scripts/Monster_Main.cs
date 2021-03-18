using System;
using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace RileyMcGowan
{
    public class Monster_Main : MonoBehaviour
    {
        private AntAIAgent antAIAgent;
        public FakeTarget currentTarget;
        public float safeDistance = 1f;

        private void Awake()
        {
            antAIAgent = GetComponent<AntAIAgent>();
        }

        void Start()
        {
            antAIAgent.SetGoal("At Target");
        }
    }
}