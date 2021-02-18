using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class CreateFog : MonoBehaviour
    {
        public IEnumerator MakeFog()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Making Fog");
        }
    }
}
