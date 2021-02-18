using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.Weaver;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Niall
{
    public class ColourChanger : NetworkBehaviour
    {
        private Color colour;

        #region Server

        void Start()
        {
            if (isServer)
            {
                InvokeRepeating("ColorChanger", 1f, 3f);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CmdSaveColor();
            }
        }

        private void ColorChanger()
        {
            if (isServer)
            {
                colour = Random.ColorHSV();
            }

            RpcMeshColor(colour);
        }

        #endregion

        #region Client

        [ClientRpc]
        public void RpcMeshColor(Color _color)
        {
            GetComponent<MeshRenderer>().material.color = _color;
        }


        [Command(ignoreAuthority = true)]
        void CmdSaveColor()
        {
            Debug.Log("Client saved colour:" + colour);
        }
        #endregion
    }
}