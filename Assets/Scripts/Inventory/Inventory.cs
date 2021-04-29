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

                Drop();
            }

            if (InputSystem.GetDevice<Keyboard>().qKey.wasPressedThisFrame)
            {
                Use(items[0]);
            }
        }

        [Command]
        public void CmdAdd(ItemBase i)
        {
            Add(i);
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

        void Use(ItemBase item)
        {
            item.Use(this.gameObject);
            items.RemoveAt(0);
        }

        public void Drop()
        {
            CmdDrop();
        }


        //  [Command(ignoreAuthority = true)]
        [Command]
       public void CmdDrop()
        {
            if (items.Count <= 0)
            {
                return;
            }
            //update transform position to hand position once complete
            GameObject droppedItem = Instantiate(items[0].prefab, handPos.transform.position, Quaternion.identity);
            Rigidbody rb = items[0].prefab.GetComponent<Rigidbody>();
            rb.velocity = Vector3.up;
            NetworkServer.Spawn(droppedItem);
            items.RemoveAt(0);
            
            onItemChangedCallback?.Invoke();
        }
    }
}