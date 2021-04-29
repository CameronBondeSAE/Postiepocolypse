using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace JonathonMiles
{
	public class PickUpItem : NetworkBehaviour
	{
		public ItemBase item;

		// Pick up the item
		public void PickUp(GameObject owner)
		{
			Debug.Log("Picking up " + item.name);
			item.Pickup(owner);
			
			CmdPickUp();
		}
		[Command(ignoreAuthority = true)]
		public void CmdPickUp()
		{
			Destroy(gameObject);
		}
	}
	
}