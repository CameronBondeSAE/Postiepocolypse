using UnityEngine;
using UnityEngine.InputSystem;


namespace JonathonMiles
{
    public class InventoryUI : MonoBehaviour
    {
		public Transform ItemGrid;	
        public GameObject inventoryUI;
        Inventory inventory;
        InventorySlot[] slots;	

        void Start () 
        {
            inventory.onItemChangedCallback += UpdateUI;
            //fills the array of slots with all available items slots in inventory
            slots = ItemGrid.GetComponentsInChildren<InventorySlot>();

			// Slots need to talk to the main inventory to add/remove themselves
			for (int i = 0; i < slots.Length; i++)
			{
				slots[i].inventory = inventory;
			}
        }
	
        void Update ()
        {
            //toggle the UI to be visible to the player
            if (InputSystem.GetDevice<Keyboard>().iKey.wasPressedThisFrame)
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
            }
            
        }

       
        void UpdateUI ()
        {
            // when we update the UI this will loop through all the slots
            for (int i = 0; i < slots.Length; i++)
            {
                //if there is an item that needs to be added to our slots it will add it
                if (i < inventory.items.Count)	
                {
                    slots[i].AddItem(inventory.items[i]);
                } else
                {
                    // or the slot will be made empty
                    slots[i].ClearSlot();
                }
            }
        }
    }
}
