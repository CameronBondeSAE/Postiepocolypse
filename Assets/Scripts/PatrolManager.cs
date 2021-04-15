using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZachFrench
{
    
    public class PatrolManager : MonoBehaviour
    {
        public List<PatrolPoint> outside;
        public List<PatrolPoint> outsideWithIndoors;
        public List<PatrolPoint> indoors;
        public List<PatrolPoint> sneaky;
    }
}
