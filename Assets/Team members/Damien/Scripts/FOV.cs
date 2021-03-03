using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Damien
{
    public class FOV : MonoBehaviour
    {
        public float viewRadius;
        public float viewAngle;

        public new Vector3 DirectionFromAngle(float angleInDegrees)
        {
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
    }
}
