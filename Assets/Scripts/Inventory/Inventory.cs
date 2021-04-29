using System.Collections.Generic;
using Mirror;
using Mirror.Examples.Chat;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace JonathonMiles
{
    public class Inventory : NetworkBehaviour
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

                Drop(items[0]);
            }

            if (InputSystem.GetDevice<Keyboard>().qKey.wasPressedThisFrame)
            {
                Use(items[0]);
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
        
            public void Drop(ItemBase item)
        {
            CmdDrop(item);
        }

        void Use(ItemBase item)
        {
            item.Use(this.gameObject);
            items.RemoveAt(0);
        }

        // [Command(ignoreAuthority = true)]
		[Command]
        void CmdDrop(ItemBase item)
        {
            items.RemoveAt(0);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
            
            //update transform position to hand position once complete
            GameObject droppedItem = Instantiate(item.prefab, handPos.transform.position, Quaternion.identity);
            Rigidbody rb = item.prefab.GetComponent<Rigidbody>();
            rb.velocity = Vector3.up;
            NetworkServer.Spawn(droppedItem);
        }
    }
}