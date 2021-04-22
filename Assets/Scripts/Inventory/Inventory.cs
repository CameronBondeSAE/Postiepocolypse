using System.Collections.Generic;
using Mirror.Examples.Chat;
using UnityEngine;
using UnityEngine.UI;

namespace JonathonMiles
{

    public class Inventory : MonoBehaviour
    {
        public delegate void OnItemChanged();

        public event OnItemChanged onItemChangedCallback;

        public int inventorySpace = 20;
        public List<ItemBase> items = new List<ItemBase>();
        public Transform handPos;


        public bool Add(ItemBase item)
        {

            if (items.Count >= inventorySpace)
            {
                Debug.Log("Inventory Full!");
                return false;
            }

            items.Add(item);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
            return true;
        }

        public void Remove(ItemBase item)
        {
            items.Remove(item);
            //items.RemoveAt(0);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
            
            //update transform position to hand position once complete
            Instantiate(item.prefab,handPos);
        }
    }
}
