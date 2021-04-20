using System.Collections.Generic;
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
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        public void Drop(ItemBase item)
        {
            
        }
    }
}
