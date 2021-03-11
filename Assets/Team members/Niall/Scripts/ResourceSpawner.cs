using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEngine;

namespace Niall
{
    public class ResourceSpawner : MonoBehaviour
    {
        public int resources = 5;
        public GameObject resource;
        private float RanX;
        private float RanZ;

        void Update()
        {
            RanX = Random.Range(-10, 10);
            RanZ = Random.Range(-10, 10);
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                for (int i = 0; i < resources; i++)
                {
                    Instantiate(resource, new Vector3(RanX, 1, RanZ), Quaternion.identity);
                    yield return new WaitForSeconds(0);

                }
            }
        }
 
    }
}