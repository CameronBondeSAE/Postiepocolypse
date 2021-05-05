using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimPearson
{
    public class Ears : MonoBehaviour
    {
        public Vector3 target;

        public void Hearing(Vector3 target)
        {
            Debug.Log("Heard Target");
            this.target = target;
        }
        
        
    }

}
