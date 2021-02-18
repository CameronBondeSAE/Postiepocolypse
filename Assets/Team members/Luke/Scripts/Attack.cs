using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class Attack : MonoBehaviour
    {
        public IEnumerator Attacking()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Attacking");
        }
    }
} 
