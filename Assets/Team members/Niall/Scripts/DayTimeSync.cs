using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Niall
{
    public class DayTimeSync : NetworkBehaviour
    {
        [SyncVar] public float Speed = 10;

        void Update()
        {
            if (isServer)
            {
                transform.Rotate(0, Speed * Time.deltaTime, 0);
                RpcCycleLight(transform.rotation);
            }
        }

        [ClientRpc]
        void RpcCycleLight(Quaternion rotate)
        {
            transform.rotation = rotate;
        }
    }
}