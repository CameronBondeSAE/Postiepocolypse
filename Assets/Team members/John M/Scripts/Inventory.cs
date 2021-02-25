using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace JonathonMiles
{

    public class Inventory : MonoBehaviour
    {
        #region Singleton
        public static Inventory instance;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.Log("More than one instance of Inventory found !!");
                return;
            }
            instance = this;
        }
        

        #endregion

        public delegate void OnItemChanged();

        public OnItemChanged onItemChangedCallBack;
        
        public int inventorySpace = 2;
        public int coinCount = 0;
        public Text coinText;
        public List<ItemBase> items = new List<ItemBase>();
        

        public bool Add(ItemBase item)
        {

            if (item.isCoin)
            {
                coinCount = coinCount + item.amount;
                Debug.Log("You got a coin!");
                coinText.text = ("x " + coinCount);
                return true;
            }
            if (items.Count >= inventorySpace)
            {
                Debug.Log("Inventory Full!");
                return false;
            }
            
            items.Add(item);
            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
            return true;
        }

        public void Remove(ItemBase item)
        {
            items.Remove(item);
            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }
    }
}
