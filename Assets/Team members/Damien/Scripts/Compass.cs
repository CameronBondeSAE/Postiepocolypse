using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damien
{
    public class Compass : MonoBehaviour
    {
        public GameObject compassNeedle;

        void Update()
        {
            compassNeedle.transform.rotation = Quaternion.Euler(transform.rotation.x, -transform.rotation.y, transform.rotation.z);
        }
    }
}
