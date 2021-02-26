using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  JonathonMiles
{
    public class ItemPickUp : Interactable
    {

        public ItemBase item;
       
        // When the player interacts with the item
        public override void Interact()
        {
            base.Interact();

            PickUp();	// Pick it up!
        }

        // Pick up the item
        void PickUp ()
        {
            Debug.Log("Picking up " + item.name);
            bool wasPickedUp = Inventory.instance.Add(item);	// Add to inventory

            // If successfully picked up
            if (wasPickedUp)
                Destroy(gameObject);	// Destroy item from scene
        }

    }

}
