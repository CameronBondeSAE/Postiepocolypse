using System.Collections.Generic;
using Mirror.Examples.Chat;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace JonathonMiles
{

    public class Inventory : MonoBehaviour
    {
        public delegate void OnItemChanged();

        public event OnItemChanged onItemChangedCallback;

        public int inventorySpace = 20;
        public List<ItemBase> items = new List<ItemBase>();
        public GameObject handPos;

        private void Update()
        {
            if (InputSystem.GetDevice<Keyboard>().vKey.wasPressedThisFrame)
            {
                if (items.Count == 0)
                {
                    Debug.Log("Nothing in Inventory");
                    return;
                }           

            Remove(items[0]);
            }
        }

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
           // items.Remove(item);
            items.RemoveAt(0);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
            
            //update transform position to hand position once complete
            Instantiate(item.prefab,handPos.transform.position, Quaternion.identity);
        }
    }
}
