using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

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
        #endregion
    }
}