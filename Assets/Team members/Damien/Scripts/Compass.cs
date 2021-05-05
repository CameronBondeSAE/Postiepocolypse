using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damien
{
    public class Compass : MonoBehaviour
    {
        public GameObject compassNeedle;
        private float turnSpeed = 5f;

        void Update()
        {
            //compassNeedle.transform.rotation = Quaternion.Euler(transform.rotation.x, -transform.rotation.y, transform.rotation.z);
            compassNeedle.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler (new Vector3 (transform.rotation.x,transform.rotation.y,transform.rotation.z)), Time.deltaTime * turnSpeed);
        }
    }
}
