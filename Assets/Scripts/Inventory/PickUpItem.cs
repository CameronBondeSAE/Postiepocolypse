using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace JonathonMiles
{
	public class PickUpItem : NetworkBehaviour
	{
		public ItemBase item;
		private Inventory inv;

		// Pick up the item
		public void PickUp(GameObject owner)
		{
			// figure out way to reference the inventory :) - Niall
			//if (inv.items.Count < inv.inventorySpace)
		//	{
				Debug.Log("Picking up " + item.name);
				item.Pickup(owner);

				CmdPickUp();
		//	}
		}
		[Command(ignoreAuthority = true)]
		private void CmdPickUp()
		{
			Destroy(gameObject);
		}
	}
	
}