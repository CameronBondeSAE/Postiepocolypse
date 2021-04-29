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
			item.Pickup(owner);
			CmdPickUp(owner);
		//	}
		}
		[Command(ignoreAuthority = true)]
		private void CmdPickUp(GameObject owner)
		{	
			Debug.Log(owner.name + "Picking up " + item.name);
         				
						Destroy(gameObject);
		}
	}
	
}