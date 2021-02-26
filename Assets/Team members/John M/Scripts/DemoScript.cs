using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JonathonMiles
{
    public class DemoScript : MonoBehaviour
    {
       public void ColourRed()
        {
            GetComponent<Renderer> ().material.color = Color.red;
        }
        
        public void ColourBlue()
        {
            GetComponent<Renderer> ().material.color = Color.blue;
        }
    }
}
