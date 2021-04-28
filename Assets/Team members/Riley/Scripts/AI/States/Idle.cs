using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace RileyMcGowan
{
    public class Idle : AntAIState
    {
        public override void Enter()
        {
            //Enter State
            base.Enter();
            //Let us know we are in idle
            Debug.Log("Poker is Currently Idle");
            //End State
            Finish();
        }
    }
}