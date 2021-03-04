using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AJ
{
    public class DropManager : NetworkBehaviour
    {
        public GameObject thingToSpawn;
        // Start is called before the first frame update
        void Start()
        {
            if (isServer)
            {
                GameObject newGO = Instantiate(thingToSpawn, Vector3.zero, Quaternion.identity);
                NetworkServer.Spawn(newGO);

                StartCoroutine(NewSpawner());
            }
        }

        
        public IEnumerator NewSpawner()
        {
            while (true)
                {
                    yield return new WaitForSeconds(2f);
                }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }

}
