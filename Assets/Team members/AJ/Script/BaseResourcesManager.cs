using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using TMPro;

namespace AJ
{
    public class BaseResourcesManager : NetworkBehaviour
    {
        public int amount;
        public TextMeshProUGUI amountUI;
        public int food;
       

        // Update is called once per frame
        void Update()
        {
            if (isServer)
            {
                if (amount < food)
                {
                    TallyFoodAmount(amount++);
                }
                else
                {
                    food++;
                }
                RpcText(amount.ToString());
                //RpcText("Hey");
            }
        }

        public void TallyFoodAmount(int i)
        {
            amount++;
        }

        [ClientRpc]
        public void RpcText(string text)
        {
            amountUI.text = text;
        }
    }

}
