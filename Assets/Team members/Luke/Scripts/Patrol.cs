using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class Patrol : MonoBehaviour
    {
        public IEnumerator FindDefoggedArea()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Search defogged area");
        }
    }
}
